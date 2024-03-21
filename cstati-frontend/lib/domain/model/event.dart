import 'event_expense.dart';
import 'enums/event_status.dart';

class Event {
  final String id;
  final String name;
  final String? excelLink;
  final EventStatus status;
  final DateTime? date;
  final String? location;
  final int? expectedGuestsCount;

  Event({
    required this.id,
    required this.name,
    required this.excelLink,
    required this.status,
    required this.date,
    required this.location,
    required this.expectedGuestsCount,
  });

  Event copyWith({
    String? id,
    String? name,
    String? excelLink,
    EventStatus? status,
    DateTime? date,
    String? location,
    int? expectedGuestsCount,
  }) {
    return Event(
      id: id ?? this.id,
      name: name ?? this.name,
      excelLink: excelLink ?? this.excelLink,
      status: status ?? this.status,
      date: date ?? this.date,
      location: location ?? this.location,
      expectedGuestsCount: expectedGuestsCount ?? this.expectedGuestsCount,
    );
}
}
