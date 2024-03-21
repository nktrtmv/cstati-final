import 'package:change_case/change_case.dart';
import 'package:event_flow/domain/model/enums/event_status.dart';

class ApiEventInfo {
  final String id;
  final String name;
  final EventStatus status;

  ApiEventInfo({
    required this.id,
    required this.name,
    required this.status,
  });

  factory ApiEventInfo.fromApi(Map<String, dynamic> map) {
    String guid = map['id'];
    String name = map['name'];
    final statusString = map['status'].toString().toCamelCase();
    EventStatus status = EventStatus.values.byName(statusString);
    return ApiEventInfo(id: guid, name: name, status: status);
  }
}
