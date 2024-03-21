import 'package:event_flow/data/api/api_util/api_util_accounts.dart';
import 'package:event_flow/domain/model/account_info.dart';
import 'package:event_flow/domain/model/enums/user_access.dart';
import 'package:event_flow/domain/repository/accounts_repository.dart';

class AccountsDataRepository extends AccountsRepository {
  final ApiUtilAccounts _apiUtil;
  AccountsDataRepository(this._apiUtil);

  @override
  Future<void> addAccess(String login, AccountAccess access) async {
    await _apiUtil.addAccess(login, access);
  }

  @override
  Future<bool> authorize(String login, String password) async {
    return _apiUtil.authorize(login, password);
  }

  @override
  Future<void> create(String login, String password, String fullName) async {
    await _apiUtil.create(login, password, fullName);
  }

  @override
  Future<void> delete(String login, String password) async {
    await _apiUtil.delete(login, password);
  }

  @override
  Future<void> deleteAccess(String login, AccountAccess access) async {
    await _apiUtil.deleteAccess(login, access);
  }

  @override
  Future<List<AccountInfo>> getAll([String? query]) async {
    return _apiUtil.getAll(query);
  }

}