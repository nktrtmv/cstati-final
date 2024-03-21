import 'package:event_flow/domain/model/event_expense.dart';
import 'package:event_flow/domain/model/event_finance.dart';
import 'package:event_flow/domain/model/exceptions/backend_exception.dart';
import 'package:event_flow/domain/repository/finance_repository.dart';
import 'package:event_flow/domain/state/event_waves_state.dart';
import 'package:event_flow/internal/dependencies/repository_module.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class EventFinanceNotifier extends AutoDisposeFamilyAsyncNotifier<EventFinance, String> {
  final FinanceRepository financeRepository = RepositoryModule.financeRepository();
  String eventId = '';

  @override
  Future<EventFinance> build(String arg) async {
    eventId = arg;
    return financeRepository.getDetails(eventId);
  }

  Future<void> actualizeRevenue() async {
    try {
      await financeRepository.actualizeRevenue(eventId);
      state = AsyncValue.data(await financeRepository.getDetails(eventId));
      ref.read(eventWavesProvider(eventId).notifier).updateToken();
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  void add(String personLogin, String description, double amount, String market) async {
    try {
      await financeRepository.addExpense(eventId, personLogin, description, amount, market);
      state = AsyncValue.data(await financeRepository.getDetails(eventId));
      ref.read(eventWavesProvider(eventId).notifier).updateToken();
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  void delete(EventExpense expense) async {
    try {
      await financeRepository.deleteExpense(eventId, expense.id);
      state = AsyncValue.data(await financeRepository.getDetails(eventId));
      ref.read(eventWavesProvider(eventId).notifier).updateToken();
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }
}

final eventFinanceProvider = AutoDisposeAsyncNotifierProviderFamily<EventFinanceNotifier, EventFinance, String>(EventFinanceNotifier.new);