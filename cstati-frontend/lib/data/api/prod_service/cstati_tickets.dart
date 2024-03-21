
import 'package:event_flow/data/api/api_models/api_event_ticket.dart';
import 'package:event_flow/data/api/contracts/cstati_tickets.dart';
import 'package:event_flow/data/api/prod_service/prod_mixin.dart';
import 'package:event_flow/domain/model/event_ticket.dart';

class CstatiTicketsProd extends CstatiTickets with ProdMixin{

  final String url;
  CstatiTicketsProd(this.url);

  @override
  Future<void> create(String eventId, EventTicket ticket) async {
    await post("$url/Create", {
      "eventId": eventId,
      "waveOrdinal": ticket.waveOrdinal,
      "ticketType": ticket.type.name,
      "price": ticket.price,
      "concurrencyToken": concurrencyToken,
    });
  }

  @override
  Future<void> delete(String eventId, EventTicket ticket) async {
    await post("$url/Delete", {
      "eventId": eventId,
      "waveOrdinal": ticket.waveOrdinal,
      "ticketType": ticket.type.name,
      "concurrencyToken": concurrencyToken,
    });
  }

  @override
  Future<List<ApiEventTicket>> getAll(String eventId, int waveOrdinal) async {
    final json = await post("$url/GetAll", {
      "eventId": eventId,
      "waveOrdinal": waveOrdinal,
    });
    concurrencyToken = json['concurrencyToken'];
    return List<ApiEventTicket>.from(json['tickets'].map((ticket) => ApiEventTicket.fromApi(ticket)));
  }

}