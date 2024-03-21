import 'package:event_flow/data/api/api_models/api_payment_collector.dart';
import 'package:event_flow/data/api/contracts/cstati_collectors.dart';
import 'package:event_flow/data/api/prod_service/prod_mixin.dart';
import 'package:event_flow/domain/model/enums/payment_bank.dart';
import 'package:event_flow/domain/model/payment_collector.dart';

class CstatiPaymentCollectorsProd extends CstatiPaymentCollectors with ProdMixin{

  final String url;
  CstatiPaymentCollectorsProd(this.url);

  @override
  Future<void> create(String eventId, String login, PaymentBank bank, String phone, String card) async {
    await post("$url/Create", {
      "eventId": eventId,
      "personLogin": login,
      "preferredBank": bank.name,
      "phoneNumber": phone,
      "cardNumber": card,
      "concurrencyToken": concurrencyToken,
    });
  }

  @override
  Future<void> delete(String eventId, String login) async {
    await post("$url/Delete", {
      "eventId": eventId,
      "personLogin": login,
      "concurrencyToken": concurrencyToken,
    });
  }

  @override
  Future<List<ApiPaymentCollector>> getAll(String eventId) async {
    final json = await post("$url/GetAll", {
      "eventId": eventId,
    });
    concurrencyToken = json['concurrencyToken'];
    return List<ApiPaymentCollector>.from(json['paymentsCollectors']!.map((pc) => ApiPaymentCollector.fromApi(pc)));
  }

  @override
  Future<void> update(String eventId, PaymentCollector collector) async {
    await post("$url/Update", {
      "eventId": eventId,
      "personLogin": collector.person.login,
      "preferredBank": collector.bank.name,
      "phoneNumber": collector.phone,
      "cardNumber": collector.cardNumber,
      "concurrencyToken": concurrencyToken,
    });
  }

}