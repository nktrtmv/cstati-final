import 'package:event_flow/domain/model/enums/payment_status.dart';

class PaymentAuditRecord {
  final DateTime date;
  final PaymentStatus statusChange;

  PaymentAuditRecord({
    required this.date,
    required this.statusChange,
  });
}
