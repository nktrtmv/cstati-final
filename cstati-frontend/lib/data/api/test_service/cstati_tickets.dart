
import 'package:event_flow/data/api/api_models/api_event_ticket.dart';
import 'package:event_flow/data/api/contracts/cstati_tickets.dart';
import 'package:event_flow/domain/model/event_ticket.dart';

class CstatiTicketsTest extends CstatiTickets {
  @override
  Future<void> create(String eventId, EventTicket ticket) async {
    print('CstatiTicketsTest::create');
  }

  @override
  Future<void> delete(String eventId, EventTicket ticket) async {
    print('CstatiTicketsTest::delete');
  }

  @override
  Future<List<ApiEventTicket>> getAll(String eventId, int waveOrdinal) async {
    print('CstatiTicketsTest::getAll');
    return [];
  }

}