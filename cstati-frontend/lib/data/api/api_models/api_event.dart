import 'package:change_case/change_case.dart';
import 'package:event_flow/domain/model/event_expense.dart';
import 'package:event_flow/domain/model/enums/event_status.dart';
import 'package:event_flow/domain/model/event_task.dart';

class ApiEvent {
  final String id;
  final String name;
  final String? excelLink;
  final EventStatus status;
  final DateTime? date;
  final String? location;
  final int? guestsCount;

  ApiEvent({
    required this.id,
    required this.name,
    this.excelLink,
    required this.status,
    this.date,
    this.location,
    this.guestsCount,
  });

  factory ApiEvent.fromApi(Map<String, dynamic> map) {
    String guid = map['id'];
    String name = map['name'];
    String? excelLink = map['excelSheetLink'];
    final statusString = map['status'].toString().toCamelCase();
    EventStatus status = EventStatus.values.byName(statusString);
    DateTime? date = map['date'] == null ? null : DateTime.parse(map['date']).toLocal();
    String? location = map['location'];
    int? guestsCount = map['expectedGuestsCount'];
    return ApiEvent(
      id: guid,
      name: name,
      excelLink: excelLink,
      status: status,
      date: date,
      location: location,
      guestsCount: guestsCount,
    );
  }
}
