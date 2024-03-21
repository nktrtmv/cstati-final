import 'package:event_flow/data/api/api_models/api_event_info.dart';
import 'package:event_flow/domain/model/event_info.dart';

class EventInfoMapper {
  static EventInfo fromApi(ApiEventInfo event) {
    return EventInfo(
      id: event.id,
      name: event.name,
      status: event.status,
    );
  }
}
