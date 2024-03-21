import 'dart:math';

import 'package:event_flow/data/api/api_models/api_account_info.dart';
import 'package:event_flow/data/api/api_models/api_event_task.dart';
import 'package:event_flow/data/api/contracts/cstati_tasks.dart';
import 'package:event_flow/domain/model/enums/task_status.dart';
import 'package:event_flow/domain/model/event_task.dart';

class CstatiTasksTest extends CstatiTasks {
  @override
  Future<void> create(String eventId, String name, String executorLogin,
      String description, DateTime deadline) async {
    print('CstatiTasksTest::create');
  }

  @override
  Future<void> delete(String eventId, String taskId) async {
    print('CstatiTasksTest::delete');
  }

  @override
  Future<List<ApiEventTask>> getAll(String eventId, [List<TaskStatus>? statusFilter]) async {
    final rnd = Random();
    print('CstatiTasksTest::getAll');
    return [];
  }

  @override
  Future<void> update(String eventId, EventTask task) async {
    print('CstatiTasksTest::update');
  }
}
