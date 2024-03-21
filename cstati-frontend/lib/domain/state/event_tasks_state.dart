import 'dart:async';

import 'package:event_flow/domain/model/event_task.dart';
import 'package:event_flow/domain/model/enums/task_status.dart';
import 'package:event_flow/domain/model/exceptions/backend_exception.dart';
import 'package:event_flow/domain/repository/tasks_repository.dart';
import 'package:event_flow/internal/dependencies/repository_module.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class EventTasksList
    extends AutoDisposeFamilyAsyncNotifier<List<EventTask>, String> {
  final TasksRepository tasksRepository = RepositoryModule.tasksRepository();
  final List<TaskStatus> filter = [];
  String eventId = '';

  @override
  Future<List<EventTask>> build(String arg) async {
    eventId = arg;
    final tasks = await tasksRepository.getAll(eventId);
    return tasks;
  }
  
  void addFilter(TaskStatus status) async {
    try {
      filter.add(status);
      state = AsyncValue.data(await tasksRepository.getAll(eventId, filter.isEmpty ? null : filter));
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }

  }

  void removeFilter(TaskStatus status) async {
    try {
      filter.remove(status);
      state = AsyncValue.data(await tasksRepository.getAll(eventId, filter.isEmpty ? null : filter));
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  void add(String name, String executorLogin, String description, DateTime deadline) async {
    try {
      await tasksRepository.create(eventId, name, executorLogin, description, deadline);
      state = AsyncValue.data(await tasksRepository.getAll(eventId, filter.isEmpty ? null : filter));
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  void toggle(String id, TaskStatus status) async {
    try {
      EventTask? task = (state.value ?? []).where((t) => t.id == id).firstOrNull;
      if (task != null) {
        final newTask = EventTask(
          id: task.id,
          name: task.name,
          executor: task.executor,
          description: task.description,
          deadline: task.deadline,
          status: status,
        );
        await tasksRepository.update(eventId, newTask);
        state = AsyncValue.data(await tasksRepository.getAll(eventId, filter.isEmpty ? null : filter));
      }
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  void remove(String taskId) async {
    try {
      tasksRepository.delete(eventId, taskId);
      state = AsyncValue.data(await tasksRepository.getAll(eventId, filter.isEmpty ? null : filter));
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }
}

final eventTasksProvider = AutoDisposeAsyncNotifierProviderFamily<
    EventTasksList, List<EventTask>, String>(EventTasksList.new);
