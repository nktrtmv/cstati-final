import 'package:event_flow/data/api/api_util/api_util.dart';
import 'package:event_flow/data/api/service/backend_service.dart';
import 'package:event_flow/data/mapper/event_ticket_mapper.dart';
import 'package:event_flow/domain/model/event_ticket.dart';

class ApiUtilTickets extends ApiUtil{

  ApiUtilTickets(super.backendService);

  Future<void> create(String eventId, EventTicket ticket) async {
    await backendService.tickets.create(eventId, ticket);
  }
  Future<void> delete(String eventId, EventTicket ticket) async {
    await backendService.tickets.delete(eventId, ticket);
  }
  Future<List<EventTicket>> getAll(String eventId, int waveOrdinal) async {
    final tickets = await backendService.tickets.getAll(eventId, waveOrdinal);
    return List<EventTicket>.from(tickets.map((ticket) => EventTicketMapper.fromApi(ticket, waveOrdinal)));
  }
}