import 'package:event_flow/data/api/api_util/api_util.dart';
import 'package:event_flow/data/api/service/backend_service.dart';
import 'package:event_flow/data/mapper/event_task_mapper.dart';
import 'package:event_flow/domain/model/enums/task_status.dart';
import 'package:event_flow/domain/model/event_task.dart';

class ApiUtilTasks extends ApiUtil{

  ApiUtilTasks(super.backendService);

  Future<List<EventTask>> getAll(String eventId, [List<TaskStatus>? statusFilter]) async {
    final tasks = await backendService.tasks.getAll(eventId, statusFilter);
    return List<EventTask>.from(tasks.map((task) => EventTaskMapper.fromApi(task)));
  }
  Future<void> create(String eventId, String name, String executorLogin, String description, DateTime deadline) async {
    await backendService.tasks.create(eventId, name, executorLogin, description, deadline);
  }
  Future<void> delete(String eventId, String taskId) async {
    await backendService.tasks.delete(eventId, taskId);
  }
  Future<void> update(String eventId, EventTask task) async {
    await backendService.tasks.update(eventId, task);
  }
}