import 'dart:async';

import 'package:event_flow/domain/model/event.dart';
import 'package:event_flow/domain/model/exceptions/backend_exception.dart';
import 'package:event_flow/domain/repository/event_repository.dart';
import 'package:event_flow/domain/state/events_screen_state.dart';
import 'package:event_flow/internal/dependencies/repository_module.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class EventNotifier extends AutoDisposeFamilyAsyncNotifier<Event, String> {
  final EventRepository eventRepository = RepositoryModule.eventRepository();
  String eventId = '';

  @override
  Future<Event> build(arg) {
    eventId = arg;
    return eventRepository.get(eventId);
  }

  Future<void> updateEvent(Event event) async {
    try {
      await eventRepository.update(event);
      state = AsyncValue.data(await eventRepository.get(eventId));
      ref.read(eventsProvider.notifier).ref.invalidateSelf();
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  Future<void> deleteEvent(Event event) async {
    try {
      await eventRepository.delete(event.id);
      ref.read(eventsProvider.notifier).ref.invalidateSelf();
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }
}


final eventProvider = AutoDisposeAsyncNotifierProviderFamily<
    EventNotifier, Event, String>(EventNotifier.new);