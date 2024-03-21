import 'package:event_flow/data/api/api_models/api_event_guest.dart';
import 'package:event_flow/data/api/contracts/concurrency_contract.dart';
import 'package:event_flow/domain/model/enums/payment_status.dart';
import 'package:event_flow/domain/model/event_guest.dart';
import 'package:file_picker/file_picker.dart';

abstract class CstatiGuests extends ConcurrencyContract {
  Future<void> addBatch(String eventId, PlatformFile csv);
  Future<void> add(String eventId, int waveOrdinal, EventGuest guest);
  Future<void> delete(String eventId, String guestId);
  Future<void> update(String eventId, EventGuest guest);
  Future<List<ApiEventGuest>> getAll(String eventId, int? waveOrdinal);
  Future<void> sendTelegramMessages(String eventId, List<PaymentStatus> statuses, String message);
  Future<void> sendTelegramPaymentMessages(String eventId, String message, DateTime deadline);
}