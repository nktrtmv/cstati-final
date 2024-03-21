import 'package:event_flow/data/api/api_util/api_util.dart';
import 'package:event_flow/data/api/service/backend_service.dart';
import 'package:event_flow/data/mapper/event_finance_mapper.dart';
import 'package:event_flow/domain/model/event_finance.dart';

class ApiUtilFinances extends ApiUtil{
  ApiUtilFinances(super.backendService);

  Future<void> addExpense(String eventId, String personLogin, String description, double amount, String market) async {
    await backendService.finances.addExpense(eventId, personLogin, description, amount, market);
  }
  Future<void> deleteExpense(String eventId, String expenseId) async {
    await backendService.finances.deleteExpense(eventId, expenseId);
  }
  Future<void> actualizeRevenue(String eventId) async {
    await backendService.finances.actualizeRevenue(eventId);
  }
  Future<EventFinance> getDetails(String eventId) async {
    final finance = await backendService.finances.getDetails(eventId);
    return EventFinanceMapper.fromApi(finance);
  }
}