import 'package:event_flow/domain/model/enums/educational_program.dart';
import 'package:event_flow/domain/model/enums/event_status.dart';
import 'package:event_flow/domain/model/enums/guest_gender.dart';
import 'package:event_flow/domain/model/enums/payment_bank.dart';
import 'package:event_flow/domain/model/enums/payment_status.dart';
import 'package:event_flow/domain/model/enums/task_status.dart';
import 'package:event_flow/domain/model/enums/ticket_type.dart';
import 'package:event_flow/domain/model/enums/user_access.dart';
import 'package:event_flow/domain/model/enums/wave_status.dart';

class Strings {
  static const String sessionKey = "sessionId";
  static const String themeKey = 'theme';

  static const String loginFormEnterLogin = "Введите логин";
  static const String loginFormEnterPassword = "Введите пароль";
  static const String loginFormEnter = "Войти";
  static const String noAccount = "Нет аккаунта?";
  static const String haveAccount = "Уже есть аккаунт?";
  static const String registerFormLogin = "Войдите";
  static const String eventStatus = "Статус";
  static const String allWaves = "Все волны";

  static const String loginFormCheckPassword = "Повторите пароль";
  static const String loginFormRegister = "Зарегистрироваться";
  static const String loginFormName = "ФИО";
  static const String expectedGuestsCount = "Предполагаемое число гостей";

  static const String events = "Мероприятия";
  static const String guests = "Гостей";
  static const String guestsCount = "Число гостей";
  static const String tgBot = "Telgram Бот";
  static const String settings = "Настройки";
  static const String createEvent = "Новое мероприятие";
  static const String cancel = "Отмена";
  static const String create = "Создать";
  static const String save = "Сохранить";
  static const String delete = "Удалить";
  static const String yes = "Да";
  static const String no = "Нет";
  static const String message = "Сообщение";

  static const String eventInfoGeneral = "Информация";
  static const String eventInfoWaves = "Волны";
  static const String eventInfoTasks = "Задачи";
  static const String eventInfoGuests = "Гости";
  static const String eventInfoFinances = "Финансы";
  static const String eventInfoAdmins = "Управление";
  static const String eventSelectDate = "Выбрать дату";
  static const String eventSelectTime = "Выбрать время";
  static const String eventEditName = 'Название мероприятия';
  static const String eventEditLocation = 'Место проведения';
  static const String eventEditLink = 'Ссылка на Excel';
  static const String eventEditDate = 'Дата мероприятия';
  static const String eventEditTime = 'Начало мероприятия';

  static const String eventTaskNew = 'Новая задача';
  static const String eventTaskName = 'Название';
  static const String eventTaskDesc = 'Описание';
  static const String eventTaskPerson = 'Исполнитель';
  static const String noTasks = 'Задач пока нет';

  static const String error = "Произошла ошибка при загрузке";
  static const String errorTextField = "Заполните поле";
  static const String errorTextFieldDouble = "Укажите правильное значение";
  static const String errorTextFieldPasswordMismatch = "Пароли не совпадают";
  static const String errorTextFieldData = "Неверный логин или пароль";
  static const String errorGuestsRequired = "Для изменения статуса необходимо указать кол-во гостей";
  static const String tooltipEdit = "Редактировать";
  static const String tooltipExcel = "Ссылка на эксель";
  static const String tooltipAddTicket = "Добавить билет";
  static const String tooltipAddGuest = "Добавить гостя";
  static const String tooltipAddBatch = "Загрузить CSV файл";
  static const String tooltipAddCollector = "Добавить коллектора";
  static const String tooltipAddExpense = "Добавить расход";
  static const String tooltipSendMessage = "Отправить сообщение";
  static const String tooltipSendMessageDeadline = "Отправить сообщение об оплате";
  static const String tooltipDelete = "Удалить";
  static const String noEvent = "Такого мероприятия не существует";
  static const String noExpenses = "Расходов пока нет";
  static const String noCollectors = "Коллекторов пока нет";

  static const String eventStart = "Начало";
  static const String tickets = "Билеты";

  static const String wave = "Волна";
  static const String startWave = "Открылась в";
  static const String endWave = "Закрылась в";
  static const String waveStart = "Запустить волну";
  static const String waveEnd = "Завершить волну";
  static const String waveDelete = "Удалить волну";
  static const String price = "Цена";
  static const String deleteTicket = "Удалить билет";
  static const String selectWave = "Выберите волну регистрации";


  static const String tableColId = "ID";
  static const String tableColName = "ФИО";
  static const String tableColGender = "Пол";
  static const String tableColTelegram = "Телеграм";
  static const String tableColPayment = "Статус оплаты";
  static const String tableColProgram = "Образовательная программа";
  static const String tableColPhone = "Номер телефона";
  static const String tableColIsLegalAge = "Есть 18";
  static const String tableColTicket = "Билет";
  static const String tableColNeedsTransfer = "Нужен трансфер";

  static const String collected = "Собрано";
  static const String balance = "Баланс";
  static const String revenue = "Доход";
  static const String expenses = "Расходы";
  static const String collectors = "Коллекторы";
  static const String selectUser = "Введите имя";
  static const String bank = "Банк";
  static const String card = "Номер карты";
  static const String market = "Магазин";

  static const String sendMessage = "Отправить сообщение";
  static const String send = "Отправить";
  static const String selectStatus = "Статус оплаты гостя";

  static const String login = 'Вход';

  static const String register = 'Регистрация';

  static const String tooltipId = 'Id мероприятия';
  static const String noWaves = 'Волн пока нет';
  static const String description = 'Описание';
  static const String actualizeRevenue = 'Актуализировать Вырочку';

  static String getEventStatus(EventStatus status) {
    return switch (status) {
      EventStatus.none => 'Ничего',
      EventStatus.notStarted => 'Планирование мероприятия',
      EventStatus.inProgress => 'Организация мероприятия',
      EventStatus.finished => 'Организация мероприятия завершена',
    };
  }

  static String getPaymentStatus(PaymentStatus status) {
    return switch (status) {
      PaymentStatus.none => 'Ничего',
      PaymentStatus.pending => 'Ожидает оплаты',
      PaymentStatus.cancelled => 'Отменено',
      PaymentStatus.paid => 'Оплачено',
      PaymentStatus.refundRequested => 'Запрошен возврат',
      PaymentStatus.refunded => 'Возвращен',
    };
  }

  static String getEventWaveStatus(EventWaveStatus status) {
    return switch (status) {
      EventWaveStatus.none => 'Ничего',
      EventWaveStatus.notStarted => 'Не началась',
      EventWaveStatus.inProgress => 'В процессе',
      EventWaveStatus.finished => 'Завершилась',
    };
  }

  static String getEventTaskStatus(TaskStatus status) {
    return switch (status) {
      TaskStatus.none => 'Ничего',
      TaskStatus.notStarted => 'Не начато',
      TaskStatus.inProgress => 'В процессе',
      TaskStatus.completed => 'Завершено',
    };
  }

  static String getEventTicketType(TicketType type) {
    return switch (type) {
      TicketType.none => 'Ничего',
      TicketType.standard => 'Стандарт',
      TicketType.comfort => 'Комфорт',
    };
  }

  static String getProgramName(EducationalProgram program) {
    return switch (program) {
    EducationalProgram.none => 'Ничего',
    EducationalProgram.softwareEngineering => 'ПИ',
    EducationalProgram.appliedMathematicsAndInformatics => 'ПМИ',
    EducationalProgram.appliedDataAnalysis => 'ПАД',
    EducationalProgram.computerScienceAndDataAnalysis => 'КНАД',
    EducationalProgram.economicsAndDataAnalysis => 'ЭАД',
    };
  }

  static String getGuestGender(GuestGender gender) {
    return switch (gender) {
      GuestGender.none => 'Ничего',
      GuestGender.male => 'Мужской',
      GuestGender.female => 'Женский',
    };
  }

  static String getPaymentBank(PaymentBank bank) {
    return switch (bank) {
      PaymentBank.none => 'Ничего',
      PaymentBank.alpha => 'Альфа',
      PaymentBank.sber => 'Сбербанк',
      PaymentBank.tinkoff => 'Тинькофф',
      PaymentBank.vtb => 'ВТБ',
    };
  }

  static String getUserAccess(AccountAccess access) {
    return switch (access) {
      AccountAccess.admin => 'Администратор',
      AccountAccess.eventAdmin => 'Администратор мероприятия',
      AccountAccess.eventResponsible => 'Организатор',
      AccountAccess.paymentsResponsible => 'Ответственный за оплаты',
    };
  }
}
