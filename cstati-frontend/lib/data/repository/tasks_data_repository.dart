import 'package:event_flow/data/api/api_util/api_util_tasks.dart';
import 'package:event_flow/domain/model/enums/task_status.dart';
import 'package:event_flow/domain/model/event_task.dart';
import 'package:event_flow/domain/repository/tasks_repository.dart';

class TasksDataRepository extends TasksRepository {
  final ApiUtilTasks _apiUtil;

  TasksDataRepository(this._apiUtil);

  @override
  Future<void> create(String eventId, String name, String executorLogin, String description, DateTime deadline) async {
    await _apiUtil.create(eventId, name, executorLogin, description, deadline);
  }

  @override
  Future<void> delete(String eventId, String taskId) async {
    await _apiUtil.delete(eventId, taskId);
  }

  @override
  Future<List<EventTask>> getAll(String eventId, [List<TaskStatus>? statusFilter]) async {
    return _apiUtil.getAll(eventId, statusFilter);
  }

  @override
  Future<void> update(String eventId, EventTask task) async {
    await _apiUtil.update(eventId, task);
  }

}