import 'package:event_flow/data/api/api_models/api_payment_audit_record.dart';
import 'package:event_flow/domain/model/payment_audit_record.dart';

class AuditRecordMapper {
  static PaymentAuditRecord fromApi(ApiPaymentAuditRecord api) {
    return PaymentAuditRecord(
      date: api.date,
      statusChange: api.statusChange,
    );
  }
}
