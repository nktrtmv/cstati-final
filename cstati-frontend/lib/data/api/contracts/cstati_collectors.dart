import 'package:event_flow/data/api/api_models/api_payment_collector.dart';
import 'package:event_flow/data/api/contracts/concurrency_contract.dart';
import 'package:event_flow/domain/model/enums/payment_bank.dart';
import 'package:event_flow/domain/model/payment_collector.dart';

abstract class CstatiPaymentCollectors extends ConcurrencyContract {
  Future<void> create(String eventId, String login, PaymentBank bank, String phone, String card);
  Future<void> delete(String eventId, String login);
  Future<void> update(String eventId, PaymentCollector collector);
  Future<List<ApiPaymentCollector>> getAll(String eventId);
}