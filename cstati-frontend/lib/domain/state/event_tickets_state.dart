
import 'package:event_flow/domain/model/enums/ticket_type.dart';
import 'package:event_flow/domain/model/event_ticket.dart';
import 'package:event_flow/domain/model/exceptions/backend_exception.dart';
import 'package:event_flow/domain/repository/tickets_repository.dart';
import 'package:event_flow/domain/state/event_waves_state.dart';
import 'package:event_flow/internal/dependencies/repository_module.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class UniqueWave {
  final String eventId;
  final int? waveOrdinal;

  UniqueWave(this.eventId, this.waveOrdinal);

  @override
  bool operator ==(Object other) {
    return other is UniqueWave && eventId == other.eventId && waveOrdinal == other.waveOrdinal;
  }

  @override
  int get hashCode => Object.hash(eventId, waveOrdinal);
}

class EventTicketsNotifier extends AutoDisposeFamilyAsyncNotifier<List<EventTicket>, UniqueWave> {
  final TicketsRepository ticketsRepository = RepositoryModule.ticketsRepository();
  late UniqueWave wave;

  @override
  Future<List<EventTicket>> build(UniqueWave arg) async {
    wave = arg;
    return ticketsRepository.getAll(wave.eventId, wave.waveOrdinal ?? 1);
  }

  void add(TicketType type, double price) async {
    try {
      if ((state.value ?? []).where((t) => t.type == type).isEmpty) {
        final newTicket = EventTicket(type: type, price: price, waveOrdinal: wave.waveOrdinal ?? 1);
        await ticketsRepository.create(wave.eventId, newTicket);
        state = AsyncValue.data(await ticketsRepository.getAll(wave.eventId, wave.waveOrdinal ?? 1));
        ref.read(eventWavesProvider(wave.eventId).notifier).updateToken();
      }
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  void delete(EventTicket ticket) async {
    try {
      await ticketsRepository.delete(wave.eventId, ticket);
      state = AsyncValue.data(await ticketsRepository.getAll(wave.eventId, wave.waveOrdinal ?? 1));
      ref.read(eventWavesProvider(wave.eventId).notifier).updateToken();
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }
}

final eventTicketsProvider = AutoDisposeAsyncNotifierProviderFamily<EventTicketsNotifier, List<EventTicket>, UniqueWave>(EventTicketsNotifier.new);