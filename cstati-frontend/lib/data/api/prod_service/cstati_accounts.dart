import 'package:change_case/change_case.dart';
import 'package:event_flow/data/api/api_models/api_account_info.dart';
import 'package:event_flow/data/api/contracts/cstati_accounts.dart';
import 'package:event_flow/data/api/prod_service/prod_mixin.dart';
import 'package:event_flow/domain/model/enums/user_access.dart';

class CstatiAccountsProd extends CstatiAccounts with ProdMixin{

  final loginToken = <String, String>{};

  final String url;
  CstatiAccountsProd(this.url);

  @override
  Future<void> addAccess(String login, AccountAccess access) async {
    await post("$url/AddAccess", {
      "login": login,
      "access": access.name.toPascalCase(),
      "concurrencyToken": loginToken['login']
    });
  }

  @override
  Future<bool> authorize(String login, String password) async {
    final json = await post("$url/Authorize", {
      "login": login,
      "password": password,
    });
    return json['succeed'];
  }

  @override
  Future<void> create(String login, String password, String fullName) async {
    await post("$url/Create", {
      "login": login,
      "password": password,
      "fullName": fullName,
    });
  }

  @override
  Future<void> delete(String login, String password) async {
    await post("$url/Delete", {
      "login": login,
      "password": password,
      "concurrencyToken": loginToken['login'],
    });
  }

  @override
  Future<void> deleteAccess(String login, AccountAccess access) async {
    await post("$url/Delete", {
      "login": login,
      "access": access.name.toPascalCase(),
      "concurrencyToken": loginToken['login']
    });
  }

  @override
  Future<List<ApiAccountInfo>> getAll([String? query]) async {
    final json = await post("$url/GetAll?limit=1000", {
      if (query != null) "query": query,
    });
    loginToken.addEntries(List<MapEntry<String,String>>.from(json['accounts'].map((a) => MapEntry<String, String>(a['login'], a['concurrencyToken']))));
    return List<ApiAccountInfo>.from(json['accounts'].map((info) => ApiAccountInfo.fromApi(info)));
  }

}