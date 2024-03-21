
import 'package:event_flow/data/api/api_models/api_event_ticket.dart';
import 'package:event_flow/domain/model/event_ticket.dart';

class EventTicketMapper {
  static EventTicket fromApi(ApiEventTicket api, int waveOrdinal) {
    return EventTicket(
      type: api.type,
      price: api.price,
      waveOrdinal: waveOrdinal,
    );
  }
}
