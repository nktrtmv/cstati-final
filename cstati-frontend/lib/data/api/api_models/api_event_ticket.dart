import 'package:change_case/change_case.dart';
import 'package:event_flow/domain/model/enums/ticket_type.dart';

class ApiEventTicket {
  final TicketType type;
  final double price;

  ApiEventTicket({
    required this.type,
    required this.price,
  });

  factory ApiEventTicket.fromApi(Map<String, dynamic> map) {
    final ticketString = map['type'].toString().toCamelCase();
    TicketType type = TicketType.values.byName(ticketString);
    double price = map['price'];
    return ApiEventTicket(type: type, price: price,);
  }
}
