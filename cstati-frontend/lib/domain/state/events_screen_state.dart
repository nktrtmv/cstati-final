import 'dart:async';

import 'package:event_flow/domain/model/event.dart';
import 'package:event_flow/domain/model/event_info.dart';
import 'package:event_flow/domain/repository/event_repository.dart';
import 'package:event_flow/internal/dependencies/repository_module.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';



class EventsList extends AutoDisposeAsyncNotifier<List<EventInfo>> {
  final EventRepository eventRepository = RepositoryModule.eventRepository();
  @override
  Future<List<EventInfo>> build() async{
    return eventRepository.getAll();
  }

  Future<String> addEvent(String name) async {
    String eventId = await eventRepository.create(name);
    ref.invalidateSelf();
    return eventId;
  }

  Future<void> search(String query) async {
    //TODO: Maybe implement search and filtering
  }
}


final eventsProvider = AsyncNotifierProvider.autoDispose<EventsList, List<EventInfo>>(EventsList.new);