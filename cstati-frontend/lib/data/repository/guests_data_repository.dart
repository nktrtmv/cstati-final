import 'package:event_flow/data/api/api_util/api_util_guests.dart';
import 'package:event_flow/domain/model/enums/payment_status.dart';
import 'package:event_flow/domain/model/event_guest.dart';
import 'package:event_flow/domain/repository/guests_repository.dart';
import 'package:file_picker/file_picker.dart';

class GuestsDataRepository extends GuestsRepository {
  final ApiUtilGuests _apiUtil;

  GuestsDataRepository(this._apiUtil);

  @override
  Future<void> add(String eventId, int waveOrdinal, EventGuest guest) async {
    await _apiUtil.add(eventId, waveOrdinal, guest);
  }

  @override
  Future<void> addBatch(String eventId, PlatformFile csv) async {
    await _apiUtil.addBatch(eventId, csv);
  }

  @override
  Future<void> delete(String eventId, String guestId) async {
    await _apiUtil.delete(eventId, guestId);
  }

  @override
  Future<List<EventGuest>> getAll(String eventId, int? waveOrdinal) async {
    return _apiUtil.getAll(eventId, waveOrdinal);
  }

  @override
  Future<void> sendTelegramMessages(String eventId, List<PaymentStatus> statuses, String message) async {
    await _apiUtil.sendTelegramMessages(eventId, statuses, message);
  }

  @override
  Future<void> sendTelegramPaymentMessages(String eventId, String message, DateTime deadline) async {
    await _apiUtil.sendTelegramPaymentMessages(eventId, message, deadline);
  }

  @override
  Future<void> update(String eventId, EventGuest guest) async {
    await _apiUtil.update(eventId, guest);
  }

}