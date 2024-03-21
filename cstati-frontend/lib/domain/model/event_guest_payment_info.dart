import 'package:event_flow/domain/model/enums/payment_status.dart';
import 'package:event_flow/domain/model/payment_audit_record.dart';

class EventGuestPaymentInfo {
  final PaymentStatus status;
  final List<PaymentAuditRecord> auditRecords;

  EventGuestPaymentInfo({
    required this.status,
    required this.auditRecords,
  });
}
