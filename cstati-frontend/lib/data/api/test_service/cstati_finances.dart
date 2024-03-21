import 'package:event_flow/data/api/api_models/api_event_finance.dart';
import 'package:event_flow/data/api/contracts/cstati_finances.dart';

class CstatiFinancesTest extends CstatiFinances {
  @override
  Future<void> actualizeRevenue(String eventId) async {
    print('CstatiFinancesTest::actualizeRevenue');
  }

  @override
  Future<void> addExpense(String eventId, String personLogin, String description, double amount, String market) async {
    print('CstatiFinancesTest::addExpense');
  }

  @override
  Future<void> deleteExpense(String eventId, String expenseId) async {
    print('CstatiFinancesTest::deleteExpense');
  }

  @override
  Future<ApiEventFinance> getDetails(String eventId) async {
    print('CstatiFinancesTest::getDetails');
    return ApiEventFinance(collected: 0, balance: 0, expenses: [], revenue: 0);
  }

}