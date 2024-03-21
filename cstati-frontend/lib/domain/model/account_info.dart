import 'package:event_flow/domain/model/enums/user_access.dart';

class AccountInfo {
  final String login;
  final String fullName;
  final List<AccountAccess> accesses;

  AccountInfo({
    required this.login,
    required this.fullName,
    required this.accesses,
  });
}
