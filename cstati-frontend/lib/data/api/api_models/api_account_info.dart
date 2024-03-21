import 'package:change_case/change_case.dart';
import 'package:event_flow/domain/model/enums/user_access.dart';

class ApiAccountInfo {
  final String login;
  final String fullName;
  final List<AccountAccess> accesses;

  ApiAccountInfo({
    required this.login,
    required this.fullName,
    required this.accesses,
  });

  factory ApiAccountInfo.fromApi(Map<String, dynamic> map) {
    String login = map['login'];
    String fullName = map['fullName'];
    List<String> accessesString = List<String>.from(map['accesses'] ?? []);

    List<AccountAccess> accesses = List<AccountAccess>.from(accessesString.map((a) => AccountAccess.values.byName(a.toCamelCase())));

    return ApiAccountInfo(login: login, fullName: fullName, accesses: accesses);
  }
}
