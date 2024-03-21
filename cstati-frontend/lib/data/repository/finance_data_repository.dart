
import 'package:event_flow/data/api/api_util/api_util_finances.dart';
import 'package:event_flow/domain/model/event_finance.dart';
import 'package:event_flow/domain/repository/finance_repository.dart';

class FinanceDataRepository extends FinanceRepository {
  final ApiUtilFinances _apiUtil;

  FinanceDataRepository(this._apiUtil);

  @override
  Future<void> actualizeRevenue(String eventId) async {
    await _apiUtil.actualizeRevenue(eventId);
  }

  @override
  Future<void> addExpense(String eventId, String personLogin, String description, double amount, String market) async {
    await _apiUtil.addExpense(eventId, personLogin, description, amount, market);
  }

  @override
  Future<void> deleteExpense(String eventId, String expenseId) async {
    await _apiUtil.deleteExpense(eventId, expenseId);
  }

  @override
  Future<EventFinance> getDetails(String eventId) async {
    return _apiUtil.getDetails(eventId);
  }


}