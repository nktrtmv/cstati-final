import 'package:event_flow/data/api/api_util/api_util.dart';
import 'package:event_flow/data/api/service/backend_service.dart';
import 'package:event_flow/data/mapper/payment_collector_mapper.dart';
import 'package:event_flow/domain/model/enums/payment_bank.dart';
import 'package:event_flow/domain/model/payment_collector.dart';

class ApiUtilCollectors extends ApiUtil{
  ApiUtilCollectors(super.backendService);

  Future<void> create(String eventId, String login, PaymentBank bank, String phone, String card) async {
    await backendService.collectors.create(eventId, login, bank, phone, card);
  }
  Future<void> delete(String eventId, String login) async {
    await backendService.collectors.delete(eventId, login);
  }
  Future<void> update(String eventId, PaymentCollector collector) async {
    await backendService.collectors.update(eventId, collector);
  }
  Future<List<PaymentCollector>> getAll(String eventId) async {
    final collectors = await backendService.collectors.getAll(eventId);
    return List<PaymentCollector>.from(collectors.map((collector) => PaymentCollectorMapper.fromApi(collector)));
  }
}