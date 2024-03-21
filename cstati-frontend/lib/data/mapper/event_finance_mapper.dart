import 'package:event_flow/data/api/api_models/api_event_finance.dart';
import 'package:event_flow/data/mapper/event_expense_mapper.dart';
import 'package:event_flow/domain/model/event_finance.dart';

class EventFinanceMapper {
  static EventFinance fromApi(ApiEventFinance api) {
    return EventFinance(
      collected: api.collected,
      balance: api.balance,
      expenses: api.expenses.map((e) => EventExpenseMapper.fromApi(e)).toList(),
      revenue: api.revenue,
    );
  }
}
