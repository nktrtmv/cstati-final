import 'package:event_flow/domain/model/enums/payment_status.dart';

class EventGuestInfo {
  final String id;
  final String fullname;
  final PaymentStatus status;

  EventGuestInfo({
    required this.id,
    required this.fullname,
    required this.status,
  });
}
