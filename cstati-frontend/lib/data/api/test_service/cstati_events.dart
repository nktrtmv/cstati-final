import 'dart:math';

import 'package:event_flow/data/api/api_models/api_event.dart';
import 'package:event_flow/data/api/api_models/api_event_info.dart';
import 'package:event_flow/data/api/contracts/cstati_events.dart';
import 'package:event_flow/domain/model/enums/event_status.dart';
import 'package:event_flow/domain/model/event.dart';

class CstatiEventsTest extends CstatiEvents {
  @override
  Future<String> create(String name) async {
    print('CstatiEventsTest::create');
    return "id";
  }

  @override
  Future<void> delete(String eventId) async {
    print('CstatiEventsTest::delete');
  }

  @override
  Future<ApiEvent> get(String eventId) async {
    print('CstatiEventsTest::get');
    return ApiEvent(id: "id", name: "name", status: EventStatus.notStarted);
  }

  @override
  Future<List<ApiEventInfo>> getAll([String? query, List<EventStatus>? statusFilter]) async {
    print('CstatiEventsTest::getAll');
    return [];
  }

  @override
  Future<void> update(Event event) async {
    print('CstatiEventsTest::update');
  }

}