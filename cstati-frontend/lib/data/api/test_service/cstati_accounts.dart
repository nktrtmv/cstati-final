import 'package:event_flow/data/api/api_models/api_account_info.dart';
import 'package:event_flow/data/api/contracts/cstati_accounts.dart';
import 'package:event_flow/domain/model/enums/user_access.dart';

class CstatiAccountsTest extends CstatiAccounts {
  @override
  Future<void> addAccess(String login, AccountAccess access) async {
    print('CstatiAccountsTest::addAccess');
  }

  @override
  Future<bool> authorize(String login, String password) async {
    print('CstatiAccountsTest::authorize');
    return true;
  }

  @override
  Future<void> create(String login, String password, String fullName) async {
    print('CstatiAccountsTest::create');
  }

  @override
  Future<void> delete(String login, String password) async {
    print('CstatiAccountsTest::delete');
  }

  @override
  Future<void> deleteAccess(String login, AccountAccess access) async {
    print('CstatiAccountsTest::deleteAccess');
  }

  @override
  Future<List<ApiAccountInfo>> getAll([String? query]) async {
    print('CstatiAccountsTest::getAll');
    return [];
  }

}