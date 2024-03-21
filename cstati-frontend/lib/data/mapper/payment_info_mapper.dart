import 'package:event_flow/data/api/api_models/api_event_guest_payment_info.dart';
import 'package:event_flow/data/mapper/audit_record_mapper.dart';
import 'package:event_flow/domain/model/event_guest_payment_info.dart';

class PaymentInfoMapper {
  static EventGuestPaymentInfo fromApi(ApiEventGuestPaymentInfo api) {
    return EventGuestPaymentInfo(
      status: api.status,
      auditRecords: api.auditRecords.map((e) => AuditRecordMapper.fromApi(e)).toList(),
    );
  }
}
