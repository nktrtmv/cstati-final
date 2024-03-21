import 'package:event_flow/domain/model/enums/event_status.dart';
import 'package:event_flow/domain/model/event.dart';
import 'package:event_flow/domain/model/event_info.dart';

abstract class EventRepository {
  Future<String> create(String name);
  Future<void> update(Event event);
  Future<void> delete(String eventId);
  Future<Event> get(String eventId);
  Future<List<EventInfo>> getAll([String? query, List<EventStatus>? statusFilter]);
}