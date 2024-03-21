
import 'package:event_flow/data/api/api_models/api_event_task.dart';
import 'package:event_flow/data/api/contracts/cstati_tasks.dart';
import 'package:event_flow/data/api/prod_service/prod_mixin.dart';
import 'package:event_flow/domain/model/enums/task_status.dart';
import 'package:event_flow/domain/model/event_task.dart';

class CstatiTasksProd extends CstatiTasks with ProdMixin{

  final String url;
  CstatiTasksProd(this.url);

  @override
  Future<void> create(String eventId, String name, String executorLogin, String description, DateTime deadline) async {
    await post("$url/Create", {
      "eventId": eventId,
      "name": name,
      "executorLogin": executorLogin,
      "description": description,
      "deadline": deadline.toUtc().toIso8601String(),
      "concurrencyToken": concurrencyToken,
    });
  }

  @override
  Future<void> delete(String eventId, String taskId) async {
    await post("$url/Delete", {
      "eventId": eventId,
      "taskId": taskId,
      "concurrencyToken": concurrencyToken,
    });
  }

  @override
  Future<List<ApiEventTask>> getAll(String eventId, [List<TaskStatus>? statusFilter]) async {
    final json = await post("$url/GetAll?limit=1000", {
      "eventId": eventId,
      "statusesFilter": (statusFilter?.map((e) => e.name) ?? []).toList(),
    });
    concurrencyToken = json['concurrencyToken'];
    return List<ApiEventTask>.from(json['tasks'].map((task) => ApiEventTask.fromApi(task)));
  }

  @override
  Future<void> update(String eventId, EventTask task) async {
    await post("$url/Update", {
      "eventId": eventId,
      "taskId": task.id,
      "name": task.name,
      "executorLogin": task.executor.login,
      "description": task.description,
      "deadline": task.deadline.toUtc().toIso8601String(),
      "status": task.status.name,
      "concurrencyToken": concurrencyToken,
    });
  }

}