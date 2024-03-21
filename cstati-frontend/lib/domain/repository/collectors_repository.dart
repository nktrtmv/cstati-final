import 'package:event_flow/domain/model/enums/payment_bank.dart';
import 'package:event_flow/domain/model/payment_collector.dart';

abstract class CollectorsRepository {
  Future<void> create(String eventId, String login, PaymentBank bank, String phone, String card);
  Future<void> delete(String eventId, String login);
  Future<void> update(String eventId, PaymentCollector collector);
  Future<List<PaymentCollector>> getAll(String eventId);
}