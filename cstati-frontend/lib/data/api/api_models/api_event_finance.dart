import 'package:event_flow/data/api/api_models/api_event_expense.dart';

class ApiEventFinance {
  final double collected;
  final double balance;
  final List<ApiEventExpense> expenses;
  final double revenue;

  ApiEventFinance({
    required this.collected,
    required this.balance,
    required this.expenses,
    required this.revenue,
  });

  factory ApiEventFinance.fromApi(Map<String, dynamic> map) {
    print(map);
    final collected = map['collected'];
    final balance = map['currentBalance'];
    final expenses = List<ApiEventExpense>.from(map['expenses'].map((e) => ApiEventExpense.fromApi(e)));
    final revenue = map['revenue'];
    return ApiEventFinance(
      collected: collected,
      balance: balance,
      expenses: expenses,
      revenue: revenue,
    );
  }
}
