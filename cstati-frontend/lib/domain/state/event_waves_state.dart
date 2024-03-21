import 'dart:async';
import 'dart:math';

import 'package:event_flow/domain/model/enums/wave_status.dart';
import 'package:event_flow/domain/model/event_wave.dart';
import 'package:event_flow/domain/model/exceptions/backend_exception.dart';
import 'package:event_flow/domain/repository/waves_repository.dart';
import 'package:event_flow/domain/state/event_tickets_state.dart';
import 'package:event_flow/internal/dependencies/repository_module.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class EventWavesList
    extends AutoDisposeFamilyAsyncNotifier<List<EventWave>, String> {
  final WavesRepository wavesRepository = RepositoryModule.wavesRepository();
  String eventId = '';
  @override
  Future<List<EventWave>> build(String arg) async {
    eventId = arg;
    return wavesRepository.getAll(eventId);
  }

  void add() async {
    try {
      await wavesRepository.create(eventId);
      state = AsyncValue.data(await wavesRepository.getAll(eventId));
      updateToken();
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  void delete(int wave) async {
    try {
      await wavesRepository.delete(eventId, wave);
      state = AsyncValue.data((state.value ?? []).where((t) => t.ordinal != wave).toList());
      updateToken();
    }  catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  void start(int waveOrdinal) async{
    try {
      if ((ref.read(eventTicketsProvider(UniqueWave(eventId, waveOrdinal)).notifier).state.value ?? []).isNotEmpty) {
        await wavesRepository.start(eventId, waveOrdinal);
        state = AsyncValue.data([
          for (EventWave w in state.value ?? [])
            if (w.ordinal == waveOrdinal)
              EventWave(ordinal: waveOrdinal, status: EventWaveStatus.inProgress, start: DateTime.now())
            else
              w
        ]);
        updateToken();
      }
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  void complete(int waveOrdinal) async {
    try {
      await wavesRepository.complete(eventId, waveOrdinal);
      state = AsyncValue.data([
        for (EventWave w in state.value ?? [])
          if (w.ordinal == waveOrdinal)
            EventWave(ordinal: w.ordinal, status: EventWaveStatus.finished, start: w.start, end: DateTime.now())
          else
            w
      ]);
      updateToken();
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  void updateToken() async {
    try {
      wavesRepository.getAll(eventId);
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }
}

final eventWavesProvider = AutoDisposeAsyncNotifierProviderFamily<EventWavesList, List<EventWave>, String>(EventWavesList.new);
