import 'package:event_flow/data/api/api_models/api_account_info.dart';
import 'package:event_flow/data/api/api_models/api_payment_collector.dart';
import 'package:event_flow/data/api/contracts/cstati_collectors.dart';
import 'package:event_flow/domain/model/enums/payment_bank.dart';
import 'package:event_flow/domain/model/payment_collector.dart';

class CstatiPaymentCollectorsTest extends CstatiPaymentCollectors {
  @override
  Future<void> create(String eventId, String login, PaymentBank bank, String phone, String card) async {
    print('CstatiPaymentCollectorsTest::create');
  }

  @override
  Future<void> delete(String eventId, String login) async {
    print('CstatiPaymentCollectorsTest::delete');
  }

  @override
  Future<List<ApiPaymentCollector>> getAll(String eventId) async {
    print('CstatiPaymentCollectorsTest::getAll');
    return [];
  }

  @override
  Future<void> update(String eventId, PaymentCollector collector) async {
    print('CstatiPaymentCollectorsTest::update');
  }

}