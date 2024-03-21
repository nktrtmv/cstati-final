import 'package:event_flow/data/api/api_models/api_event_wave.dart';
import 'package:event_flow/domain/model/event_ticket.dart';
import 'package:event_flow/domain/model/event_wave.dart';

class EventWaveMapper {
  static EventWave fromApi(ApiEventWave api) {
    return EventWave(
      ordinal: api.ordinal,
      status: api.status,
      start: api.start,
      end: api.end,
    );
  }
}
