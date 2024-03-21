import 'package:change_case/change_case.dart';
import 'package:event_flow/data/api/api_models/api_event.dart';
import 'package:event_flow/data/api/api_models/api_event_info.dart';
import 'package:event_flow/data/api/contracts/cstati_events.dart';
import 'package:event_flow/data/api/prod_service/prod_mixin.dart';
import 'package:event_flow/domain/model/enums/event_status.dart';
import 'package:event_flow/domain/model/event.dart';

class CstatiEventsProd extends CstatiEvents with ProdMixin{

  final String url;
  CstatiEventsProd(this.url);

  @override
  Future<String> create(String name) async {
    final json = await post("$url/Create", {
      "name": name,
    });
    return json['eventId'];
  }

  @override
  Future<void> delete(String eventId) async {
    await post("$url/Delete", {
      "eventId": eventId,
      "concurrencyToken": concurrencyToken,
    });
  }

  @override
  Future<ApiEvent> get(String eventId) async {
    final json = await post("$url/Get", {
      "eventId": eventId,
    });
    concurrencyToken = json['event']['concurrencyToken'];
    return ApiEvent.fromApi(json['event']);
  }

  @override
  Future<List<ApiEventInfo>> getAll([String? query, List<EventStatus>? statusFilter]) async {
    final json = await post("$url/GetAll?limit=1000", {
      if (query != null) "query": query,
      "statusesFilter": (statusFilter?.map((e) => e.name) ?? []).toList(),
    });
    return List<ApiEventInfo>.from(json['events'].map((info) => ApiEventInfo.fromApi(info)));
  }

  @override
  Future<void> update(Event event) async {
    await post("$url/Update", {
      "eventId": event.id,
      "excelSheetLink": event.excelLink,
      "status": event.status.name.toPascalCase(),
      "date": event.date == null ? null : event.date!.toUtc().toIso8601String(),
      "location": event.location,
      "expectedGuestsCount": event.expectedGuestsCount,
      "concurrencyToken": concurrencyToken,
    });
  }

}