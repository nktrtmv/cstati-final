import 'package:event_flow/data/api/api_models/api_payment_collector.dart';
import 'package:event_flow/data/mapper/account_info_mapper.dart';
import 'package:event_flow/data/mapper/event_guest_info_mapper.dart';
import 'package:event_flow/domain/model/payment_collector.dart';

class PaymentCollectorMapper {
  static PaymentCollector fromApi(ApiPaymentCollector api) {
    return PaymentCollector(
      person: AccountInfoMapper.fromApi(api.person),
      bank: api.bank,
      phone: api.phone,
      cardNumber: api.cardNumber,
      guests: api.guests.map((e) => EventGuestInfoMapper.fromApi(e)).toList(),
    );
  }
}
