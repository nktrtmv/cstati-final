import 'package:event_flow/domain/model/event_expense.dart';

class EventFinance {
  final double collected;
  final double balance;
  final List<EventExpense> expenses;
  final double revenue;

  EventFinance({
    required this.collected,
    required this.balance,
    required this.expenses,
    required this.revenue,
  });
}
