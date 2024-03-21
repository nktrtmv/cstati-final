import 'package:event_flow/domain/model/event_ticket.dart';

abstract class TicketsRepository {
  Future<void> create(String eventId, EventTicket ticket);
  Future<void> delete(String eventId, EventTicket ticket);
  Future<List<EventTicket>> getAll(String eventId, int waveOrdinal);
}