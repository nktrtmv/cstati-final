import 'package:change_case/change_case.dart';
import 'package:event_flow/data/api/api_models/api_event_guest_payment_info.dart';
import 'package:event_flow/domain/model/enums/educational_program.dart';
import 'package:event_flow/domain/model/enums/guest_gender.dart';
import 'package:event_flow/domain/model/enums/ticket_type.dart';

class ApiEventGuest {
  final String id;
  final String fullName;
  final GuestGender gender;
  final String telegram;
  final ApiEventGuestPaymentInfo paymentInfo;
  final EducationalProgram program;
  final String phone;
  final bool isLegalAge;
  final TicketType ticket;
  final bool needsTransfer;

  ApiEventGuest({
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

  factory ApiEventGuest.fromApi(Map<String, dynamic> map) {
    String id = map['guestId'];
    String fullName = map['fullName'];
    final genderString = map['gender'].toString().toCamelCase();
    GuestGender gender = GuestGender.values.byName(genderString);
    String telegram = map['telegramLogin'];
    ApiEventGuestPaymentInfo paymentInfo = ApiEventGuestPaymentInfo.fromApi(map['paymentInfo']);
    final programString = map['educationalProgram'].toString().toCamelCase();
    EducationalProgram program = EducationalProgram.values.byName(programString);
    String phone = map['phoneNumber'];
    bool isLegalAge = map['isLegalAge'] ?? false;
    final ticketString = map['ticketType'].toString().toCamelCase();
    TicketType ticket = TicketType.values.byName(ticketString);
    bool needsTransfer = map['transferIsRequired'] ?? false;
    return ApiEventGuest(
      id: id,
      fullName: fullName,
      gender: gender,
      telegram: telegram,
      paymentInfo: paymentInfo,
      program: program,
      phone: phone,
      isLegalAge: isLegalAge,
      ticket: ticket,
      needsTransfer: needsTransfer,
    );
  }
}
