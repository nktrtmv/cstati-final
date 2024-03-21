import 'package:event_flow/domain/model/enums/ticket_type.dart';

class EventTicket {
  final TicketType type;
  final double price;
  final int waveOrdinal;

  EventTicket({
    required this.type,
    required this.price,
    required this.waveOrdinal,
  });
}
