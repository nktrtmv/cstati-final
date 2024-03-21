import 'package:event_flow/data/api/api_models/api_event.dart';
import 'package:event_flow/domain/model/event.dart';

class EventMapper {
  static Event fromApi(ApiEvent event) {
    return Event(
      id: event.id,
      name: event.name,
      excelLink: event.excelLink,
      status: event.status,
      date: event.date,
      location: event.location,
      expectedGuestsCount: event.guestsCount,
    );
  }
}
