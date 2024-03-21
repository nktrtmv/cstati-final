import 'package:event_flow/data/api/api_models/api_event_guest.dart';
import 'package:event_flow/data/api/contracts/cstati_guests.dart';
import 'package:event_flow/domain/model/enums/payment_status.dart';
import 'package:event_flow/domain/model/event_guest.dart';
import 'package:file_picker/file_picker.dart';

class CstatiGuestsTest extends CstatiGuests {
  @override
  Future<void> addBatch(String eventId, PlatformFile csv) async {
    print('CstatiGuestsTest::addBatch');
  }

  @override
  Future<void> add(String eventId, int waveOrdinal, EventGuest guest) async {
    print('CstatiGuestsTest::add');
  }

  @override
  Future<void> delete(String eventId, String guestId) async {
    print('CstatiGuestsTest::delete');
  }

  @override
  Future<List<ApiEventGuest>> getAll(String eventId, int? waveOrdinal) async {
    print('CstatiGuestsTest::getAll');
    return [];
  }

  @override
  Future<void> sendTelegramMessages(String eventId, List<PaymentStatus> statuses, String message) async {
    print('CstatiGuestsTest::sendTelegramMessages');
  }

  @override
  Future<void> sendTelegramPaymentMessages(String eventId, String message, DateTime deadline) async {
    print('CstatiGuestsTest::sendTelegramPaymentMessages');
  }

  @override
  Future<void> update(String eventId, EventGuest guest) async {
    print('CstatiGuestsTest::update');
  }

}