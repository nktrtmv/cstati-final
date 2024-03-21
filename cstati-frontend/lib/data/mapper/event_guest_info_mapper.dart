
import 'package:event_flow/data/api/api_models/api_event_guest_info.dart';
import 'package:event_flow/domain/model/event_guest_info.dart';

class EventGuestInfoMapper {
  static EventGuestInfo fromApi(ApiEventGuestInfo api) {
    return EventGuestInfo(
      id: api.id,
      fullname: api.fullName,
      status: api.status,
    );
  }
}
