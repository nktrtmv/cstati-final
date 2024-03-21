import 'package:change_case/change_case.dart';
import 'package:event_flow/domain/model/enums/payment_status.dart';

class ApiPaymentAuditRecord {
  final DateTime date;
  final PaymentStatus statusChange;

  ApiPaymentAuditRecord({
    required this.date,
    required this.statusChange,
  });
  
  factory ApiPaymentAuditRecord.fromApi(Map<String, dynamic> map) {
    DateTime date = DateTime.parse(map['date']).toLocal();
    final statusString = map['statusChangedTo'].toString().toCamelCase();
    PaymentStatus statusChange = PaymentStatus.values.byName(statusString);
    return ApiPaymentAuditRecord(date: date, statusChange: statusChange,);
  }
}
