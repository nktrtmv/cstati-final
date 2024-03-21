import 'dart:async';

import 'package:event_flow/domain/model/enums/payment_bank.dart';
import 'package:event_flow/domain/model/exceptions/backend_exception.dart';
import 'package:event_flow/domain/model/payment_collector.dart';
import 'package:event_flow/domain/repository/collectors_repository.dart';
import 'package:event_flow/domain/state/event_waves_state.dart';
import 'package:event_flow/internal/dependencies/repository_module.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class CollectorsNotifier
    extends AutoDisposeFamilyAsyncNotifier<List<PaymentCollector>, String> {
  final CollectorsRepository collectorsRepository = RepositoryModule.collectorsRepository();
  late String eventId;
  @override
  Future<List<PaymentCollector>> build(String arg) async {
    eventId = arg;
    return collectorsRepository.getAll(eventId);
  }

  Future<void> add(String login, PaymentBank bank, String phone, String card) async {
    try {
      await collectorsRepository.create(eventId, login, bank, phone, card);
      state = AsyncValue.data(await collectorsRepository.getAll(eventId));
      ref.read(eventWavesProvider(eventId).notifier).updateToken();
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  Future<void> delete(String login) async {
    try {
      await collectorsRepository.delete(eventId, login);
      state = AsyncValue.data(await collectorsRepository.getAll(eventId));
      ref.read(eventWavesProvider(eventId).notifier).updateToken();
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  Future<void> updateCollector(PaymentCollector collector) async {
    try {
      await collectorsRepository.update(eventId, collector);
      state = AsyncValue.data(await collectorsRepository.getAll(eventId));
      ref.read(eventWavesProvider(eventId).notifier).updateToken();
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }
}

final eventCollectorsProvider = AutoDisposeAsyncNotifierProviderFamily<
    CollectorsNotifier, List<PaymentCollector>, String>(CollectorsNotifier.new);
