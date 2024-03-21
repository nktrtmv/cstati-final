import 'package:event_flow/data/api/api_models/api_event_ticket.dart';
import 'package:event_flow/data/api/contracts/concurrency_contract.dart';
import 'package:event_flow/domain/model/event_ticket.dart';

abstract class CstatiTickets extends ConcurrencyContract {
  Future<void> create(String eventId, EventTicket ticket);
  Future<void> delete(String eventId, EventTicket ticket);
  Future<List<ApiEventTicket>> getAll(String eventId, int waveOrdinal);
}