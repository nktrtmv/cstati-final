import 'package:event_flow/domain/model/enums/educational_program.dart';
import 'package:event_flow/domain/model/event_guest_payment_info.dart';
import 'package:event_flow/domain/model/enums/guest_gender.dart';
import 'package:event_flow/domain/model/enums/ticket_type.dart';

class EventGuest {
  final String id;
  final String fullName;
  final GuestGender gender;
  final String telegram;
  final EventGuestPaymentInfo paymentInfo;
  final EducationalProgram program;
  final String phone;
  final bool isLegalAge;
  final TicketType ticket;
  final bool needsTransfer;

  EventGuest({
    required this.id,
    required this.fullName,
    required this.gender,
    required this.telegram,
    required this.paymentInfo,
    required this.program,
    required this.phone,
    required this.isLegalAge,
    required this.ticket,
    required this.needsTransfer,
});
}
