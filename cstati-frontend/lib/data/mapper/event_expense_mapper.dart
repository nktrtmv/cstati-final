import 'package:event_flow/data/api/api_models/api_event_expense.dart';
import 'package:event_flow/data/mapper/account_info_mapper.dart';
import 'package:event_flow/domain/model/event_expense.dart';

class EventExpenseMapper {
  static EventExpense fromApi(ApiEventExpense api) {
    return EventExpense(
      id: api.id,
      person: AccountInfoMapper.fromApi(api.person),
      description: api.description,
      amount: api.amount,
      market: api.market,
    );
  }
}
