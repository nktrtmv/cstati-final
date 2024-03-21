import 'package:event_flow/domain/model/enums/event_status.dart';

class EventInfo {
  final String id;
  final String name;
  final EventStatus status;

  EventInfo({
    required this.id,
    required this.name,
    required this.status,
  });
}
