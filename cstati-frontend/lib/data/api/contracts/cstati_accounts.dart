import 'package:event_flow/data/api/api_models/api_account_info.dart';
import 'package:event_flow/data/api/contracts/concurrency_contract.dart';
import 'package:event_flow/domain/model/enums/user_access.dart';

abstract class CstatiAccounts extends ConcurrencyContract{
  Future<bool> authorize(String login, String password);
  Future<void> create(String login, String password, String fullName);
  Future<void> delete(String login, String password);
  Future<void> addAccess(String login, AccountAccess access);
  Future<void> deleteAccess(String login, AccountAccess access);
  Future<List<ApiAccountInfo>> getAll([String? query]);
}