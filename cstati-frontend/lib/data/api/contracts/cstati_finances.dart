import 'package:event_flow/data/api/api_models/api_event_finance.dart';
import 'package:event_flow/data/api/contracts/concurrency_contract.dart';

abstract class CstatiFinances extends ConcurrencyContract {
  Future<void> addExpense(String eventId, String personLogin, String description, double amount, String market);
  Future<void> deleteExpense(String eventId, String expenseId);
  Future<void> actualizeRevenue(String eventId);
  Future<ApiEventFinance> getDetails(String eventId);
}