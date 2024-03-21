import 'package:event_flow/data/api/api_models/api_event_task.dart';
import 'package:event_flow/data/api/contracts/concurrency_contract.dart';
import 'package:event_flow/domain/model/enums/task_status.dart';
import 'package:event_flow/domain/model/event_task.dart';

abstract class CstatiTasks extends ConcurrencyContract {
  Future<List<ApiEventTask>> getAll(String eventId, [List<TaskStatus>? statusFilter]);
  Future<void> create(String eventId, String name, String executorLogin, String description, DateTime deadline);
  Future<void> delete(String eventId, String taskId);
  Future<void> update(String eventId, EventTask task);
}