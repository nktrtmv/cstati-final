import 'package:event_flow/domain/model/account_info.dart';
import 'package:event_flow/domain/model/enums/payment_bank.dart';
import 'package:event_flow/domain/model/event_guest_info.dart';

class PaymentCollector {
  final AccountInfo person;
  final PaymentBank bank;
  final String phone;
  final String cardNumber;
  final List<EventGuestInfo> guests;

  PaymentCollector({
    required this.person,
    required this.bank,
    required this.phone,
    required this.cardNumber,
    required this.guests,
  });
}
