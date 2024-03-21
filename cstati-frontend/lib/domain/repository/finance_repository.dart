import 'package:event_flow/domain/model/event_finance.dart';

abstract class FinanceRepository {
  Future<void> addExpense(String eventId, String personLogin, String description, double amount, String market);
  Future<void> deleteExpense(String eventId, String expenseId);
  Future<void> actualizeRevenue(String eventId);
  Future<EventFinance> getDetails(String eventId);
}