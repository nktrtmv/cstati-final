import 'package:event_flow/domain/model/account_info.dart';
import 'package:event_flow/domain/model/enums/user_access.dart';

abstract class AccountsRepository {
  Future<bool> authorize(String login, String password);
  Future<void> create(String login, String password, String fullName);
  Future<void> delete(String login, String password);
  Future<void> addAccess(String login, AccountAccess access);
  Future<void> deleteAccess(String login, AccountAccess access);
  Future<List<AccountInfo>> getAll([String? query]);
}