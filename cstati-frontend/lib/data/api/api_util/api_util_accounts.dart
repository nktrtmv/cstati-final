import 'package:event_flow/data/api/api_util/api_util.dart';
import 'package:event_flow/data/mapper/account_info_mapper.dart';
import 'package:event_flow/domain/model/account_info.dart';
import 'package:event_flow/domain/model/enums/user_access.dart';

class ApiUtilAccounts extends ApiUtil {
  ApiUtilAccounts(super.backendService);

  Future<bool> authorize(String login, String password) async {
    return backendService.accounts.authorize(login, password);
  }
  Future<void> create(String login, String password, String fullName) async {
    await backendService.accounts.create(login, password, fullName);
  }
  Future<void> delete(String login, String password) async {
    await backendService.accounts.delete(login, password);
  }
  Future<void> addAccess(String login, AccountAccess access) async {
    await backendService.accounts.addAccess(login, access);
  }
  Future<void> deleteAccess(String login, AccountAccess access) async {
    await backendService.accounts.deleteAccess(login, access);
  }
  Future<List<AccountInfo>> getAll([String? query]) async {
    final accounts = await backendService.accounts.getAll(query);
    return List<AccountInfo>.from(accounts.map((account) => AccountInfoMapper.fromApi(account)));
  }
}