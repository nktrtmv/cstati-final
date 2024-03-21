import 'package:change_case/change_case.dart';
import 'package:event_flow/data/api/api_models/api_account_info.dart';
import 'package:event_flow/data/api/api_models/api_event_guest_info.dart';
import 'package:event_flow/domain/model/enums/payment_bank.dart';

class ApiPaymentCollector {
  final ApiAccountInfo person;
  final PaymentBank bank;
  final String phone;
  final String cardNumber;
  final List<ApiEventGuestInfo> guests;

  ApiPaymentCollector({
    required this.person,
    required this.bank,
    required this.phone,
    required this.cardNumber,
    required this.guests,
  });

  factory ApiPaymentCollector.fromApi(Map<String, dynamic> map) {
    ApiAccountInfo person = ApiAccountInfo.fromApi(map['person']);
    final bankString = map['preferredBank'].toString().toCamelCase();
    PaymentBank bank = PaymentBank.values.byName(bankString);
    String phone = map['phoneNumber'];
    String cardNumber = map['cardNumber'];
    List<ApiEventGuestInfo> guests = List<ApiEventGuestInfo>.from(map['guests'].map((g) => ApiEventGuestInfo.fromApi(g)));
    return ApiPaymentCollector(
      person: person,
      bank: bank,
      phone: phone,
      cardNumber: cardNumber,
      guests: guests,
    );
  }
}
