import 'package:event_flow/data/api/api_models/api_event_guest.dart';
import 'package:event_flow/data/mapper/payment_info_mapper.dart';
import 'package:event_flow/domain/model/event_guest.dart';

class EventGuestMapper {
  static EventGuest fromApi(ApiEventGuest api) {
    return EventGuest(
      id: api.id,
      fullName: api.fullName,
      gender: api.gender,
      telegram: api.telegram,
      paymentInfo: PaymentInfoMapper.fromApi(api.paymentInfo),
      program: api.program,
      phone: api.phone,
      isLegalAge: api.isLegalAge,
      ticket: api.ticket,
      needsTransfer: api.needsTransfer,
    );
  }
}
