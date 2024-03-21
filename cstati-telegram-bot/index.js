const { Telegraf, Telegram, Extra, Markup, Scenes } = require('telegraf')
const LocalSession = require('telegraf-session-local')
const { Pool } = require('pg')
require('dotenv').config()
const { eventEmitter, sendRefundRequest } = require('./kafka_service')


const pool = new Pool({
    host: 'telegram_bot_postgres',
    port: 5432
})

const bot = new Telegraf(process.env.BOT_TOKEN)
const questionsChatId = process.env.FAQ_CHAT_ID;

const selectEventScene = new Scenes.BaseScene("selectEventScene")
const selectActionScene = new Scenes.BaseScene("selectActionScene")
const configChatScene = new Scenes.BaseScene("configChatScene")
const askQuestionScene = new Scenes.BaseScene("askQuestionScene")
const askEventQuestionScene = new Scenes.BaseScene("askEventQuestionScene")


const stage = new Scenes.Stage([
    selectEventScene,
    selectActionScene,
    configChatScene,
    askQuestionScene,
    askEventQuestionScene
])
const leave = Scenes.Stage.leave


bot.use((new LocalSession({ database: 'user_data/users_db.json' })).middleware())
bot.use(stage.middleware())
//bot.use(async (ctx, next) => { if (ctx.chat.type == 'private') next() })


// gRPC
var PROTO_PATH = __dirname + '/api/cstati_telegram_bot_service.proto';
const { loadPackageDefinition, Server, ServerCredentials } = require('@grpc/grpc-js')
const { loadSync } = require('@grpc/proto-loader')
var packageDefinition = loadSync(
    PROTO_PATH,
    {
        keepCase: true,
        longs: String,
        enums: String,
        defaults: true,
        oneofs: true
    });
var cstatiMessages = loadPackageDefinition(packageDefinition).Cstati.Telegram.Bot.Api;


async function getActionKeyboard(login, eventId) {
    const result = await pool.query('SELECT payment_status FROM UsersEvents WHERE login = $1 AND event_id = $2 LIMIT 1', [login, eventId])
    let actionsKeyboard = [
        ['Задать вопрос по мероприятию'],
        ['Вернуться назад']
    ];
    console.log(result);
    if (result.rowCount > 0 && result.rows[0].payment_status === 3) {
        actionsKeyboard.splice(0, 0, ['Запросить возврат'])
    }
    return actionsKeyboard;
}

async function selectEvent(ctx) {
    const result = await pool.query('SELECT name FROM Events WHERE is_completed = FALSE');
    if (result.rowCount > 0) {
        events = result.rows.map((row) => [row.name])
        events.push(['Обновить']);
        events.push(['Задать вопрос']);
        ctx.reply('Выбери мероприятие из списка:', Markup
            .keyboard(events)
            .oneTime()
            .resize());
    } else {
        ctx.reply('Пока нет мероприятий. Приходи потом', Markup
            .keyboard([['Обновить'], ['Задать вопрос']])
            .oneTime()
            .resize());
    }
}

/* GENERAL BOT COMMANDS */

bot.start(async (ctx) => {
    if (ctx.chat.type === 'private') {
        let chatId = ctx.message.chat.id;
        let login = ctx.message.from.username;
        await pool.query('INSERT INTO Users(chat_id,login) VALUES ($1, $2) ON CONFLICT DO NOTHING', [chatId, login])
        ctx.scene.enter('selectEventScene')
    } else {
        ctx.reply('Привет');
        ctx.reply(`chatId is: ${ctx.message.chat.id}`);
        ctx.scene.enter('configChatScene')
    }
});

/* GROUP CHAT HANDLERS */

configChatScene.enter((ctx) => {
    ctx.reply('Отправте мне ID мероприятия.');
})

configChatScene.on('text', async (ctx) => {
    let eventId = ctx.message.text;
    let chatId = ctx.message.chat.id;
    const result = await pool.query('SELECT name FROM Events WHERE id = $1', [eventId]);
    if (result.rowCount > 0) {
        await pool.query('UPDATE Events SET chat_id = $1 WHERE id = $2', [chatId, eventId]);
        ctx.reply(`Чат ${chatId} добавлен к мероприятию ${result.rows[0].name}`);
        leave();
    } else {
        ctx.reply(`Такого id ${eventId} не найдено.`)
    }
})

/* SELECT EVENT SCENE */

selectEventScene.enter(selectEvent)

selectEventScene.hears('Обновить', selectEvent)

selectEventScene.on('text', async (ctx) => {
    console.log(ctx.message.text)
    if (ctx.message.text == 'Задать вопрос') {
        ctx.scene.enter('askQuestionScene');
    } else {
        const result = await pool.query('SELECT id FROM Events WHERE name = $1', [ctx.message.text]);
        let login = ctx.message.from.username;
        if (result.rowCount > 0) {
            ctx.session.eventId = result.rows[0].id;
            let login = ctx.message.from.username;
            let eventId = ctx.session.eventId;
            await pool.query('INSERT INTO UsersEvents (event_id, login, payment_status) VALUES ($1, $2, $3) ON CONFLICT(login) DO NOTHING', [eventId, login, 0])
            ctx.scene.enter('selectActionScene');
        } else {
            ctx.reply('Такого мероприятия нет');
        }
    }
})

/* ASK QUESTIONS SCENE */

askQuestionScene.enter((ctx) => {
    ctx.reply('Напиши сюда свой вопрос:', Markup
        .keyboard([['Отменить']])
        .oneTime()
        .resize());
});

askQuestionScene.hears('Отменить', (ctx) => {
    leave();
    ctx.scene.enter('selectEventScene');
})

askQuestionScene.on('text', (ctx) => {
    let text = ctx.message.text;
    let login = ctx.message.from.username;
    bot.telegram.sendMessage(questionsChatId, `Вопрос от @${login}\n${text}`);
    ctx.reply('Сообщение отправлено. Тебе ответят в личку.');
    leave();
    ctx.scene.enter('selectEventScene');
})

/* SELECT ACTION SCENE */

selectActionScene.enter(async (ctx) => {
    let login = ctx.message.from.username;
    let eventId = ctx.session.eventId;
    let actionsKeyboard = await getActionKeyboard(login, eventId);
    ctx.reply('Выбери действие', Markup
        .keyboard(actionsKeyboard)
        .oneTime()
        .resize())
});

selectActionScene.hears('Вернуться назад', (ctx) => {
    leave();
    ctx.scene.enter('selectEventScene');
});

selectActionScene.hears('Задать вопрос по мероприятию', (ctx) => {
    leave();
    ctx.scene.enter('askEventQuestionScene');
});


selectActionScene.hears('Запросить возврат', async (ctx) => {
    let chatId = ctx.message.chat.id
    let login = ctx.message.from.username;
    let eventId = ctx.session.eventId;
    const result = await pool.query('SELECT payment_status FROM UsersEvents WHERE login = $1 AND event_id = $2 LIMIT 1', [login, eventId])
    let resp = 'Тебя нет в базе данных, перезапусти бота командой /start'
    if (result.rowCount > 0) {
        if (result.rows[0].payment_status === 3) {
            resp = 'Ты запросил возврат'
            sendRefundRequest(eventId, login);
            await pool.query('INSERT INTO UsersEvents (event_id, login, payment_status) VALUES ($1, $2, $3) ON CONFLICT(login) DO UPDATE SET payment_status = excluded.payment_status', [eventId, login, 4])
        } else if (result.rows[0].payment_status === 4) {
            resp = 'Ты уже запросил возврат'
        } else if (result.rows[0].payment_status === 6) {
            resp = 'Возврат уже оформлен'
        } else {
            resp = 'Для запроса возврата нужно оплатить билет'
        }
    }
    let actionsKeyboard = await getActionKeyboard(login, eventId);
    ctx.reply(resp, Markup
        .keyboard(actionsKeyboard)
        .oneTime()
        .resize())
})


/* ASK EVENT QUESTION SCENE */

askEventQuestionScene.enter((ctx) => {
    ctx.reply('Напиши сюда свой вопрос:', Markup
        .keyboard([['Отменить']])
        .oneTime()
        .resize())
})

askEventQuestionScene.hears('Отменить', async (ctx) => {
    leave();
    ctx.scene.enter('selectActionScene');
});

askEventQuestionScene.on('text', async (ctx) => {
    let text = ctx.message.text;
    let login = ctx.message.from.username;
    const result = await pool.query('SELECT chat_id from Events WHERE id = $1 LIMIT 1', [ctx.session.eventId]);
    let replyMsg = 'Чат для вопросов еще не готов. Отправь сообщенеие позже.'
    if (result.rowCount > 0 && result.rows[0].chat_id) {
        replyMsg = 'Сообщение отправлено. Тебе ответят в личку.'
        bot.telegram.sendMessage(result.rows[0].chat_id, `Вопрос от @${login}\n${text}`);
    }
    ctx.reply(replyMsg);
    leave();
    ctx.scene.enter('selectActionScene');
})


/* KAFKA EVENTS LISTENERS */

eventEmitter.on('start', async (eventId, eventName) => {
    console.log('StartEventRequest');
    await pool.query('INSERT INTO Events(id, name) VALUES ($1, $2)', [eventId, eventName]);
});

eventEmitter.on('complete', async (eventId) => {
    await pool.query('UPDATE Events SET is_completed = True WHERE id = $1', [eventId]);
});

eventEmitter.on('paymentStatus', async (status, login, eventId) => {
    await pool.query('INSERT INTO UsersEvents (event_id, login, payment_status) VALUES ($1, $2, $3) ON CONFLICT(login) DO UPDATE SET payment_status = $3', [eventId, login, status]);
});

/* GRPC HANDLERS */

function sendMessage(call, callback) {
    call.request.messages.forEach(async (message) => {
        let login = message.recipient_login
        const result = await pool.query('SELECT chat_id FROM Users WHERE login = $1 LIMIT 1', [login]);
        if (result.rowCount > 0) {
            let text = message.message;
            let chatId = result.rows[0].chat_id;
            console.log('id: %s. text: %s', chatId, text);
            bot.telegram.sendMessage(chatId, text);
        }
    });
    return callback(null, {})
}



/* STARTUP */

bot.launch()

function getServer() {
    var server = new Server();
    server.addService(cstatiMessages.CstatiTelegramBotService.service, {
        SendMessage: sendMessage,
    });
    return server;
}


var grpcServer = getServer();
grpcServer.bindAsync('0.0.0.0:5005', ServerCredentials.createInsecure(), () => {
    grpcServer.start();
});


process.once('SIGINT', () => {
    bot.stop('SIGINT')
    pool.end()
})
process.once('SIGTERM', () => {
    bot.stop('SIGTERM')
    pool.end()
})