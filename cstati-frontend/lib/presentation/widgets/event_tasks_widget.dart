import 'package:event_flow/domain/model/event_task.dart';
import 'package:event_flow/domain/model/enums/task_status.dart';
import 'package:event_flow/domain/state/event_tasks_state.dart';
import 'package:event_flow/presentation/dialogs/create_task_dialog.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:intl/intl.dart';

final selectStatusProvider = StateProvider<List<TaskStatus>>((ref) => []);

class EventTasks extends ConsumerStatefulWidget {
  final String eventId;

  const EventTasks({super.key, required this.eventId});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() => _EventTasksState();
}

class _EventTasksState extends ConsumerState<EventTasks> {
  @override
  Widget build(BuildContext context) {
    final tasksFuture = ref.watch(eventTasksProvider(widget.eventId));
    return tasksFuture.when(
      data: (tasks) {
        final selectedStatuses = ref.watch(selectStatusProvider);
        return Scaffold(
          appBar: null,
          body: Center(
            child: Container(
              padding: const EdgeInsets.all(16),
              constraints: const BoxConstraints(
                maxWidth: 1000,
              ),
              child: Column(
                children: [
                  Wrap(
                    spacing: 8.0,
                    runSpacing: 8.0,
                    children: TaskStatus.values
                        .skip(1)
                        .map(
                          (status) => FilterChip(
                            label: Text(Strings.getEventTaskStatus(status)),
                            selected: selectedStatuses.contains(status),
                            onSelected: (value) {
                              if (value) {
                                ref.read(selectStatusProvider.notifier).state =
                                    [...ref.read(selectStatusProvider), status];
                                ref
                                    .read(eventTasksProvider(widget.eventId)
                                        .notifier)
                                    .addFilter(status);
                              } else {
                                ref.read(selectStatusProvider.notifier).state =
                                    ref
                                        .read(selectStatusProvider)
                                        .where((s) => s != status)
                                        .toList();
                                ref
                                    .read(eventTasksProvider(widget.eventId)
                                        .notifier)
                                    .removeFilter(status);
                              }
                            },
                          ),
                        )
                        .toList(),
                  ),
                  const SizedBox(
                    height: 16,
                  ),
                  tasks.isEmpty
                      ? Center(
                          child: Text(
                            Strings.noTasks,
                            style: Theme.of(context).textTheme.displayMedium,
                          ),
                        )
                      : Expanded(
                          child: ListView.separated(
                            itemCount: tasks.length,
                            separatorBuilder: (context, index) =>
                                const Divider(),
                            itemBuilder: (context, index) {
                              final task = tasks.elementAt(index);
                              return ExpansionTile(
                                leading: _getTaskStatusBadge(task.status),
                                title: Text(
                                    "Задача: ${task.name} Сделать до: ${DateFormat('dd.MM.yyyy kk:mm').format(task.deadline)}"),
                                subtitle: Text(
                                    "Исполнитель: ${task.executor.fullName}"),
                                trailing: Row(
                                  mainAxisSize: MainAxisSize.min,
                                  children: [
                                    DropdownButton(
                                      value: task.status,
                                      items: TaskStatus.values
                                          .skip(1)
                                          .map((e) => DropdownMenuItem(
                                              value: e,
                                              child: Text(
                                                  Strings.getEventTaskStatus(
                                                      e))))
                                          .toList(),
                                      onChanged: (value) {
                                        if (value != null) {
                                          ref
                                              .read(eventTasksProvider(
                                              widget.eventId)
                                              .notifier)
                                              .toggle(task.id,
                                              value);
                                        }

                                      },
                                    ),
                                    const SizedBox(
                                      width: 20,
                                    ),
                                    IconButton(
                                      onPressed: () {
                                        ref
                                            .read(eventTasksProvider(
                                                    widget.eventId)
                                                .notifier)
                                            .remove(task.id);
                                      },
                                      icon: const Icon(Icons.delete),
                                      color: Colors.red,
                                    ),
                                  ],
                                ),
                                shape: const Border(),
                                children: [
                                  Text(
                                    task.description,
                                    style:
                                        Theme.of(context).textTheme.bodyLarge,
                                  )
                                ],
                              );
                            },
                          ),
                        ),
                ],
              ),
            ),
          ),
          floatingActionButton: FloatingActionButton(
            onPressed: () {
              _createTaskDialog(context);
            },
            child: const Icon(Icons.add),
          ),
        );
      },
      error: (obj, trace) {
        print(trace);
        return const Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              Text(Strings.error),
            ],
          ),
        );
      },
      loading: () {
        return const Center(
          child: CircularProgressIndicator(),
        );
      },
    );
  }

  Widget _getTaskStatusBadge(TaskStatus status) {
    final Color clr = switch (status) {
      TaskStatus.none => Colors.blueGrey,
      TaskStatus.notStarted => Colors.blue,
      TaskStatus.inProgress => Colors.yellow,
      TaskStatus.completed => Colors.green,
    };
    return Badge(
      backgroundColor: clr,
      label: Text(Strings.getEventTaskStatus(status)),
    );
  }

  Future<void> _createTaskDialog(BuildContext context) async {
    return showDialog(
      context: context,
      builder: (context) => CreateTaskDialog(
        eventId: widget.eventId,
      ),
    );
  }
}
