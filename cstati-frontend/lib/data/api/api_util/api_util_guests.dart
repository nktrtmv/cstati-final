import 'package:event_flow/data/api/api_util/api_util.dart';
import 'package:event_flow/data/api/service/backend_service.dart';
import 'package:event_flow/data/mapper/event_guest_mapper.dart';
import 'package:event_flow/domain/model/enums/payment_status.dart';
import 'package:event_flow/domain/model/event_guest.dart';
import 'package:file_picker/file_picker.dart';

class ApiUtilGuests extends ApiUtil{
  ApiUtilGuests(super.backendService);

  Future<void> addBatch(String eventId, PlatformFile csv) async {
    await backendService.guests.addBatch(eventId, csv);
  }
  Future<void> add(String eventId, int waveOrdinal, EventGuest guest) async {
    await backendService.guests.add(eventId, waveOrdinal, guest);
  }
  Future<void> delete(String eventId, String guestId) async {
    await backendService.guests.delete(eventId, guestId);
  }
  Future<void> update(String eventId, EventGuest guest) async {
    await backendService.guests.update(eventId, guest);
  }
  Future<List<EventGuest>> getAll(String eventId, int? waveOrdinal) async {
    final guests = await backendService.guests.getAll(eventId, waveOrdinal);
    return List<EventGuest>.from(guests.map((guest) => EventGuestMapper.fromApi(guest)));
  }
  Future<void> sendTelegramMessages(String eventId, List<PaymentStatus> statuses, String message) async {
    await backendService.guests.sendTelegramMessages(eventId, statuses, message);
  }
  Future<void> sendTelegramPaymentMessages(String eventId, String message, DateTime deadline) async {
    await backendService.guests.sendTelegramPaymentMessages(eventId, message, deadline);
  }
}