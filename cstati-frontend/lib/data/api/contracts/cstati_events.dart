import 'package:event_flow/data/api/api_models/api_event.dart';
import 'package:event_flow/data/api/api_models/api_event_info.dart';
import 'package:event_flow/data/api/contracts/concurrency_contract.dart';
import 'package:event_flow/domain/model/enums/event_status.dart';
import 'package:event_flow/domain/model/event.dart';

abstract class CstatiEvents extends ConcurrencyContract{
  Future<String> create(String name);
  Future<void> update(Event event);
  Future<void> delete(String eventId);
  Future<ApiEvent> get(String eventId);
  Future<List<ApiEventInfo>> getAll([String? query, List<EventStatus>? statusFilter]);
}