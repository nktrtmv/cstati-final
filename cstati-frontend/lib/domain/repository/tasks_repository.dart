import 'package:event_flow/domain/model/enums/task_status.dart';
import 'package:event_flow/domain/model/event_task.dart';

abstract class TasksRepository {
  Future<List<EventTask>> getAll(String eventId, [List<TaskStatus>? statusFilter]);
  Future<void> create(String eventId, String name, String executorLogin, String description, DateTime deadline);
  Future<void> delete(String eventId, String taskId);
  Future<void> update(String eventId, EventTask task);
}
