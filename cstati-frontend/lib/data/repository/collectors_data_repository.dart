import 'package:event_flow/data/api/api_util/api_util_collectors.dart';
import 'package:event_flow/domain/model/enums/payment_bank.dart';
import 'package:event_flow/domain/model/payment_collector.dart';
import 'package:event_flow/domain/repository/collectors_repository.dart';

class CollectorsDataRepository extends CollectorsRepository {
  final ApiUtilCollectors _apiUtil;

  CollectorsDataRepository(this._apiUtil);

  @override
  Future<void> create(String eventId, String login, PaymentBank bank, String phone, String card) async {
    await _apiUtil.create(eventId, login, bank, phone, card);
  }

  @override
  Future<void> delete(String eventId, String login) async {
    await _apiUtil.delete(eventId, login);
  }

  @override
  Future<List<PaymentCollector>> getAll(String eventId) async {
    return _apiUtil.getAll(eventId);
  }

  @override
  Future<void> update(String eventId, PaymentCollector collector) async {
    return _apiUtil.update(eventId, collector);
  }

}