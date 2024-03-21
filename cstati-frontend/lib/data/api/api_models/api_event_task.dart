import 'package:change_case/change_case.dart';
import 'package:event_flow/data/api/api_models/api_account_info.dart';
import 'package:event_flow/domain/model/enums/task_status.dart';

class ApiEventTask {
  final String id;
  final String name;
  final ApiAccountInfo executor;
  final String description;
  final DateTime deadline;
  final TaskStatus status;

  ApiEventTask({
    required this.id,
    required this.name,
    required this.executor,
    required this.description,
    required this.deadline,
    required this.status,
  });

  factory ApiEventTask.fromApi(Map<String, dynamic> map) {
    String id = map['id'];
    String name = map['name'];
    ApiAccountInfo executor = ApiAccountInfo.fromApi(map['executor']);
    String description = map['description'];
    DateTime deadline = DateTime.parse(map['deadline']).toLocal();
    final statusString = map['status'].toString().toCamelCase();
    TaskStatus status = TaskStatus.values.byName(statusString);
    return ApiEventTask(
      id: id,
      name: name,
      executor: executor,
      description: description,
      deadline: deadline,
      status: status,
    );
  }
}
