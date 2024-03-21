# 1. Гайд по загрузке батча гостей через файл

При возникновении проблем обращайтесь в telegram @nktrtmv. 

Для получения csv файла из таблички в google sheets нужно создать новый лист в таблице для конвертации в нужный формат.

Пример: https://docs.google.com/spreadsheets/d/1vwkYHeGZwcYNA3wqSNpHCF2dkgglHanfMK59LS9qGBQ/edit?usp=sharing

## Описание формата

Необходимо, чтобы в csv файле первой строкой была строка с названием столбцов.
Эта строка должна быть:
```csv
FullName,Gender,TelegramLogin,EducationalProgram,PhoneNumber,IsLegalAge,PreferredTicketType,TransferIsRequested
```
Последний столбец необазателен.
Значения в каждой ячейке каждой строки обязательны.

### Примеры

```csv
FullName,Gender,TelegramLogin,EducationalProgram,PhoneNumber,IsLegalAge,PreferredTicketType,TransferIsRequested
лывотт ывотп ывлопт,1,@sdnsd,1,89001112233,TRUE,1,TRUE
аылот ылопт,2,@afhdb,3,+7 964 111 18 22,FALSE,2,FALSE
```

```csv
FullName,Gender,TelegramLogin,EducationalProgram,PhoneNumber,IsLegalAge,PreferredTicketType
лывотт ывотп ывлопт,1,@sdnsd,1,89001112233,TRUE,1
аылот ылопт,2,@afhdb,3,+7 964 111 18 22,FALSE,2
```

### Описание формата каждого столбцы

#### Gender

Парень –> 1 \
Девушка -> 2

#### TelegramLogin

Необходимо, чтобы в начале был символ `@`

#### EducationalProgram

ПИ -> 1 \
ПМИ -> 2 \
ПАД -> 3 \
КНАД -> 4 \
ЭАД -> 5

#### IsLegalAge 

Есть 18 -> TRUE или true \
Нет 18 -> FALSE или false 

#### PreferredTicketType

Стандарт -> 1 \
Комфорт -> 2 

#### TransferIsRequired

Есть 18 -> TRUE или true \
Нет 18 -> FALSE или false

# 2. Гайд по настройке телеграм-бота

### Получение токена
Пишете https://t.me/BotFather этому боту в телеграме, нажимаете `/newbot` заполняете что вас просят, получаете сообщение с токеном бота.

### Получение id чата для вопросов
Вам нужно будет получить id для чата с вопросами. Это делается через сторонних ботов, например вот какой-то [гайд](https://docs.leadconverter.su/faq/populyarnye-voprosy/telegram/kak-uznat-id-telegram-gruppy-chata). id чата группы должен начинаться с `-`.

### Заполнение .env файла
`.env` файл имеет вид 
```
BOT_TOKEN=<Токен телеграм бота>
TOPIC_NAME=cstati-events-workflows-events
FAQ_CHAT_ID=<ID чата для вопросов>
PGUSER=postgres
PGPASSWORD=postgres
PGDATABASE=cstati-telegram-bot
```

В нужные места вставляете токен бота и id чата куда будут присылаться вопросы.