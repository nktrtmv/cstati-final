
import 'package:event_flow/data/api/api_util/api_util_events.dart';
import 'package:event_flow/domain/model/enums/event_status.dart';
import 'package:event_flow/domain/model/event.dart';
import 'package:event_flow/domain/model/event_info.dart';
import 'package:event_flow/domain/repository/event_repository.dart';

class EventDataRepository extends EventRepository {
  final ApiUtilEvents _apiUtil;

  EventDataRepository(this._apiUtil);

  @override
  Future<String> create(String name) async {
    return _apiUtil.create(name);
  }

  @override
  Future<void> delete(String eventId) async {
    await _apiUtil.delete(eventId);
  }

  @override
  Future<Event> get(String eventId) async {
    return _apiUtil.get(eventId);
  }

  @override
  Future<List<EventInfo>> getAll([String? query, List<EventStatus>? statusFilter]) async {
    return _apiUtil.getAll(query, statusFilter);
  }

  @override
  Future<void> update(Event event) async {
    await _apiUtil.update(event);
  }

}