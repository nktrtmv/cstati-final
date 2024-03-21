import 'package:change_case/change_case.dart';
import 'package:event_flow/data/api/api_models/api_payment_audit_record.dart';
import 'package:event_flow/domain/model/enums/payment_status.dart';

class ApiEventGuestPaymentInfo {
  final PaymentStatus status;
  final List<ApiPaymentAuditRecord> auditRecords;

  ApiEventGuestPaymentInfo({
    required this.status,
    required this.auditRecords,
  });

  factory ApiEventGuestPaymentInfo.fromApi(Map<String, dynamic> map) {
    final statusString = map['status'].toString().toCamelCase();
    PaymentStatus status = PaymentStatus.values.byName(statusString);
    List<ApiPaymentAuditRecord> auditRecords = List<ApiPaymentAuditRecord>.from(map['auditRecords'].map((r) => ApiPaymentAuditRecord.fromApi(r)));
    return ApiEventGuestPaymentInfo(status: status, auditRecords: auditRecords,);
  }
}
