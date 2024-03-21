import 'package:event_flow/data/api/api_models/api_account_info.dart';

class ApiEventExpense {
  final String id;
  final ApiAccountInfo person;
  final String description;
  final double amount;
  final String market;

  ApiEventExpense({
    required this.id,
    required this.person,
    required this.description,
    required this.amount,
    required this.market,
  });

  factory ApiEventExpense.fromApi(Map<String, dynamic> map) {
    final id = map['id'];
    final person = ApiAccountInfo.fromApi(map['person']);
    final amount = map['amount'];
    final description = map['description'];
    final market = map['market'];
    return ApiEventExpense(
      id: id,
      person: person,
      description: description,
      amount: amount,
      market: market,
    );
  }
}
