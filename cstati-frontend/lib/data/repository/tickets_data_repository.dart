import 'package:event_flow/data/api/api_util/api_util_tickets.dart';
import 'package:event_flow/domain/model/event_ticket.dart';
import 'package:event_flow/domain/repository/tickets_repository.dart';

class TicketsDataRepository extends TicketsRepository {
  final ApiUtilTickets _apiUtil;

  TicketsDataRepository(this._apiUtil);

  @override
  Future<void> create(String eventId, EventTicket ticket) async {
    await _apiUtil.create(eventId, ticket);
  }

  @override
  Future<void> delete(String eventId, EventTicket ticket) async {
    await _apiUtil.delete(eventId, ticket);
  }

  @override
  Future<List<EventTicket>> getAll(String eventId, int waveOrdinal) async {
    return _apiUtil.getAll(eventId, waveOrdinal);
  }

}