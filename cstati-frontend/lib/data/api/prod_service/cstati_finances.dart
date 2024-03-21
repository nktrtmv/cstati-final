import 'package:event_flow/data/api/api_models/api_event_finance.dart';
import 'package:event_flow/data/api/contracts/cstati_finances.dart';
import 'package:event_flow/data/api/prod_service/prod_mixin.dart';

class CstatiFinancesProd extends CstatiFinances with ProdMixin {

  final String url;
  CstatiFinancesProd(this.url);

  @override
  Future<void> actualizeRevenue(String eventId) async {
    await post("$url/ActualizeRevenue", {
      "eventId": eventId,
      "concurrencyToken": concurrencyToken,
    });
  }

  @override
  Future<void> addExpense(String eventId, String personLogin, String description, double amount, String market) async {
    await post("$url/AddExpense", {
      "eventId": eventId,
      "personLogin": personLogin,
      "description": description,
      "amount": amount,
      "market": market,
      "concurrencyToken": concurrencyToken,
    });
  }

  @override
  Future<void> deleteExpense(String eventId, String expenseId) async {
    await post("$url/DeleteExpense", {
      "eventId": eventId,
      "expenseId": expenseId,
      "concurrencyToken": concurrencyToken,
    });
  }

  @override
  Future<ApiEventFinance> getDetails(String eventId) async {
    final json = await post("$url/GetDetails?expensesLimit=1000", {
      "eventId": eventId,
    });
    concurrencyToken = json['concurrencyToken'];
    return ApiEventFinance.fromApi(json);
  }

}