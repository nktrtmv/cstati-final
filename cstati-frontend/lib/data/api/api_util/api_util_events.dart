import 'package:event_flow/data/api/api_util/api_util.dart';
import 'package:event_flow/data/mapper/event_info_mapper.dart';
import 'package:event_flow/data/mapper/event_mapper.dart';
import 'package:event_flow/domain/model/enums/event_status.dart';
import 'package:event_flow/domain/model/event.dart';
import 'package:event_flow/domain/model/event_info.dart';

class ApiUtilEvents extends ApiUtil{
  ApiUtilEvents(super.backendService);

  Future<String> create(String name) async {
    return backendService.events.create(name);
  }
  Future<void> update(Event event) async {
    await backendService.events.update(event);
  }
  Future<void> delete(String eventId) async {
    await backendService.events.delete(eventId);
  }
  Future<Event> get(String eventId) async {
    final event = await backendService.events.get(eventId);
    return EventMapper.fromApi(event);
  }
  Future<List<EventInfo>> getAll([String? query, List<EventStatus>? statusFilter]) async {
    final events = await backendService.events.getAll(query, statusFilter);
    return List<EventInfo>.from(events.map((event) => EventInfoMapper.fromApi(event)));
  }
}