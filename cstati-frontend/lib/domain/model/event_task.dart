import 'package:event_flow/domain/model/account_info.dart';
import 'package:event_flow/domain/model/enums/task_status.dart';

class EventTask {
  final String id;
  final String name;
  final AccountInfo executor;
  final String description;
  final DateTime deadline;
  final TaskStatus status;

  EventTask({
    required this.id,
    required this.name,
    required this.executor,
    required this.description,
    required this.deadline,
    required this.status,
  });
}
