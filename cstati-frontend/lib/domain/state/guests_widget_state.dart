import 'dart:async';

import 'package:event_flow/domain/model/event_guest.dart';
import 'package:event_flow/domain/model/exceptions/backend_exception.dart';
import 'package:event_flow/domain/repository/guests_repository.dart';
import 'package:event_flow/domain/state/event_tickets_state.dart';
import 'package:event_flow/domain/state/event_waves_state.dart';
import 'package:event_flow/internal/dependencies/repository_module.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';


class EventGuestsList extends AutoDisposeFamilyAsyncNotifier<List<EventGuest>, UniqueWave> {
  final GuestsRepository guestsRepository = RepositoryModule.guestsRepository();
  late String eventId;
  int? waveOrdinal;

  @override
  Future<List<EventGuest>> build(UniqueWave arg) async {
    eventId = arg.eventId;
    waveOrdinal = arg.waveOrdinal;
    return guestsRepository.getAll(eventId, waveOrdinal);
  }

  Future<void> add(EventGuest guest) async {
    try {
      await guestsRepository.add(eventId, waveOrdinal ?? 1, guest);
      state = AsyncValue.data(await guestsRepository.getAll(eventId, waveOrdinal));
      ref.read(eventWavesProvider(eventId).notifier).updateToken();
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  Future<void> addBatch(PlatformFile csv) async {
    try {
      await guestsRepository.addBatch(eventId, csv);
      state = AsyncValue.data(await guestsRepository.getAll(eventId, waveOrdinal));
      ref.read(eventWavesProvider(eventId).notifier).updateToken();
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  Future<void> updateGuest(EventGuest guest) async {
    try {
      await guestsRepository.update(eventId, guest);
      state = AsyncValue.data(await guestsRepository.getAll(eventId, waveOrdinal));
      ref.read(eventWavesProvider(eventId).notifier).updateToken();
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  Future<void> delete(String guestId) async {
    try {
      await guestsRepository.delete(eventId, guestId);
      state = AsyncValue.data(await guestsRepository.getAll(eventId, waveOrdinal));
      ref.read(eventWavesProvider(eventId).notifier).updateToken();
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }
}

final eventGuestsProvider = AutoDisposeAsyncNotifierProviderFamily<EventGuestsList, List<EventGuest>, UniqueWave>(EventGuestsList.new);