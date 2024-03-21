import 'package:event_flow/domain/model/account_info.dart';

class EventExpense {
  final String id;
  final AccountInfo person;
  final String description;
  final double amount;
  final String market;

  EventExpense({
    required this.id,
    required this.person,
    required this.description,
    required this.amount,
    required this.market,
  });
}
