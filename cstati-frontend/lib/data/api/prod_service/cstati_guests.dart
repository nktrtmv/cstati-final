import 'package:change_case/change_case.dart';
import 'package:event_flow/data/api/api_models/api_event_guest.dart';
import 'package:event_flow/data/api/contracts/cstati_guests.dart';
import 'package:event_flow/data/api/prod_service/prod_mixin.dart';
import 'package:event_flow/domain/model/enums/payment_status.dart';
import 'package:event_flow/domain/model/event_guest.dart';
import 'package:file_picker/file_picker.dart';

class CstatiGuestsProd extends CstatiGuests with ProdMixin{

  final String url;
  CstatiGuestsProd(this.url);

  @override
  Future<void> addBatch(String eventId, PlatformFile csv) async {
    await multipart(
        '$url/AddBatch',
        {
          "eventId": eventId,
          "concurrencyToken": concurrencyToken,
        },
        csv);
  }

  @override
  Future<void> add(String eventId, int waveOrdinal, EventGuest guest) async {
    await post("$url/Add", {
      "eventId": eventId,
      "guest": {
        "fullName": guest.fullName,
        "gender": guest.gender.name.toPascalCase(),
        "telegramLogin": guest.telegram,
        "educationalProgram": guest.program.name.toPascalCase(),
        "phoneNumber": guest.phone,
        "isLegalAge": guest.isLegalAge,
        "preferredTicketType": guest.ticket.name.toPascalCase(),
        "isTransferRequested": guest.needsTransfer,
      },
      "concurrencyToken": concurrencyToken
    });
  }

  @override
  Future<void> delete(String eventId, String guestId) async {
    await post("$url/Delete", {
      "eventId": eventId,
      "guestId": guestId,
      "concurrencyToken": concurrencyToken,
    });
  }

  @override
  Future<List<ApiEventGuest>> getAll(String eventId, int? waveOrdinal) async {
    final json = await post("$url/GetAll", {
      "eventId": eventId,
      "waveOrdinal": waveOrdinal,
    });
    concurrencyToken = json['concurrencyToken'];
    return List<ApiEventGuest>.from(json['guests'].map((guest) => ApiEventGuest.fromApi(guest)));
  }

  @override
  Future<void> sendTelegramMessages(String eventId, List<PaymentStatus> statuses, String message) async {
    await post("$url/SendTelegramMessages", {
      "eventId": eventId,
      "recipientsPaymentStatuses": statuses.map((e) => e.name.toPascalCase()).toList(),
      "message": message,
    });
  }

  @override
  Future<void> sendTelegramPaymentMessages(String eventId, String message, DateTime deadline) async {
    await post("$url/SendPaymentTelegramMessages", {
      "eventId": eventId,
      "deadline": deadline.toUtc().toIso8601String(),
      "message": message,
      "concurrencyToken": concurrencyToken,
    });
  }

  @override
  Future<void> update(String eventId, EventGuest guest) async {
    await post("$url/Update", {
      "eventId": eventId,
      "guestId": guest.id,
      "fullName": guest.fullName,
      "gender": guest.gender.name.toPascalCase(),
      "telegramLogin": guest.telegram,
      "paymentStatusChangeTo": guest.paymentInfo.status.name.toPascalCase(),
      "educationalProgram": guest.program.name.toPascalCase(),
      "phoneNumber": guest.phone,
      "isLegalAge": guest.isLegalAge,
      "ticketType": guest.ticket.name.toPascalCase(),
      "transferIsRequired": guest.needsTransfer,
      "concurrencyToken": concurrencyToken,
    });
  }

}