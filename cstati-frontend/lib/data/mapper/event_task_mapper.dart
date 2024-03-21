import 'package:event_flow/data/api/api_models/api_event_task.dart';
import 'package:event_flow/data/mapper/account_info_mapper.dart';
import 'package:event_flow/domain/model/event_task.dart';

class EventTaskMapper {
  static EventTask fromApi(ApiEventTask task) {
    return EventTask(
      id: task.id,
      name: task.name,
      executor: AccountInfoMapper.fromApi(task.executor),
      description: task.description,
      deadline: task.deadline,
      status: task.status,
    );
  }
}
