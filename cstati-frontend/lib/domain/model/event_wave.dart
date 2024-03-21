import 'package:event_flow/domain/model/enums/wave_status.dart';
import 'package:event_flow/domain/model/event_ticket.dart';

class EventWave {
  final int ordinal;
  final EventWaveStatus status;
  final DateTime? start;
  final DateTime? end;

  EventWave({
    required this.ordinal,
    required this.status,
    this.start,
    this.end,
  });
}
