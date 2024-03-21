import 'package:event_flow/data/repository/accounts_data_repository.dart';
import 'package:event_flow/data/repository/collectors_data_repository.dart';
import 'package:event_flow/data/repository/event_data_repository.dart';
import 'package:event_flow/data/repository/finance_data_repository.dart';
import 'package:event_flow/data/repository/guests_data_repository.dart';
import 'package:event_flow/data/repository/tasks_data_repository.dart';
import 'package:event_flow/data/repository/tickets_data_repository.dart';
import 'package:event_flow/data/repository/waves_data_repository.dart';
import 'package:event_flow/domain/repository/accounts_repository.dart';
import 'package:event_flow/domain/repository/collectors_repository.dart';
import 'package:event_flow/domain/repository/event_repository.dart';
import 'package:event_flow/domain/repository/finance_repository.dart';
import 'package:event_flow/domain/repository/guests_repository.dart';
import 'package:event_flow/domain/repository/tasks_repository.dart';
import 'package:event_flow/domain/repository/tickets_repository.dart';
import 'package:event_flow/domain/repository/waves_repository.dart';
import 'package:event_flow/internal/dependencies/api_module.dart';

class RepositoryModule {
  static EventRepository? _eventRepository;
  static TasksRepository? _tasksRepository;
  static WavesRepository? _wavesRepository;
  static TicketsRepository? _ticketsRepository;
  static FinanceRepository? _financeRepository;
  static GuestsRepository? _guestsRepository;
  static CollectorsRepository? _collectorsRepository;
  static AccountsRepository? _accountsRepository;
  
  static EventRepository eventRepository() {
    _eventRepository ??= EventDataRepository(ApiModule.apiUtilEvents());
    return _eventRepository!;
  }

  static TasksRepository tasksRepository() {
    _tasksRepository ??= TasksDataRepository(ApiModule.apiUtilTasks());
    return _tasksRepository!;
  }

  static WavesRepository wavesRepository() {
    _wavesRepository ??= WavesDataRepository(ApiModule.apiUtilWaves());
    return _wavesRepository!;
  }

  static TicketsRepository ticketsRepository() {
    _ticketsRepository ??= TicketsDataRepository(ApiModule.apiUtilTickets());
    return _ticketsRepository!;
  }

  static FinanceRepository financeRepository() {
    _financeRepository ??= FinanceDataRepository(ApiModule.apiUtilFinances());
    return _financeRepository!;
  }

  static GuestsRepository guestsRepository() {
    _guestsRepository ??= GuestsDataRepository(ApiModule.apiUtilGuests());
    return _guestsRepository!;
  }

  static CollectorsRepository collectorsRepository() {
    _collectorsRepository ??= CollectorsDataRepository(ApiModule.apiUtilCollectors());
    return _collectorsRepository!;
  }

  static AccountsRepository accountsRepository() {
    _accountsRepository ??= AccountsDataRepository(ApiModule.apiUtilAccounts());
    return _accountsRepository!;
  }
}