import 'package:change_case/change_case.dart';
import 'package:event_flow/domain/model/enums/payment_status.dart';

class ApiEventGuestInfo {
  final String id;
  final String fullName;
  final PaymentStatus status;

  ApiEventGuestInfo({
    required this.id,
    required this.fullName,
    required this.status,
  });

  factory ApiEventGuestInfo.fromApi(Map<String, dynamic> map) {
    String id = map['id'];
    String fullName = map['fullName'];
    final statusString = map['paymentStatus'].toString().toCamelCase();
    PaymentStatus status = PaymentStatus.values.byName(statusString);
    return ApiEventGuestInfo(
      id: id,
      fullName: fullName,
      status: status,
    );
  }
}
