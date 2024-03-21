import 'package:event_flow/domain/model/enums/wave_status.dart';

class ApiEventWave {
  final int ordinal;
  final EventWaveStatus status;
  final DateTime? start;
  final DateTime? end;

  ApiEventWave({
    required this.ordinal,
    required this.status,
    this.start,
    this.end,
  });
  
  factory ApiEventWave.fromApi(Map<String, dynamic> map) {
    int number = map['ordinal'];
    EventWaveStatus status = EventWaveStatus.none;
    if (map['startedAt'] == null) {
      status = EventWaveStatus.notStarted;
    } else if (map['completedAt'] == null) {
      status = EventWaveStatus.inProgress;
    } else {
      status = EventWaveStatus.finished;
    }
    DateTime? start = map['startedAt'] == null ? null : DateTime.parse(map['startedAt']).toLocal();
    DateTime? end = map['completedAt'] == null ? null : DateTime.parse(map['completedAt']).toLocal();
    print(start);
    return ApiEventWave(ordinal: number, status: status, start: start, end: end,);
  }
}
