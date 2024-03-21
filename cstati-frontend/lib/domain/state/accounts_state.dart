import 'dart:async';

import 'package:event_flow/domain/model/account_info.dart';
import 'package:event_flow/domain/model/enums/user_access.dart';
import 'package:event_flow/domain/model/exceptions/backend_exception.dart';
import 'package:event_flow/domain/repository/accounts_repository.dart';
import 'package:event_flow/internal/dependencies/repository_module.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class AccountsNotifier extends AutoDisposeAsyncNotifier<List<AccountInfo>> {
  final AccountsRepository accountsRepository =
      RepositoryModule.accountsRepository();

  @override
  Future<List<AccountInfo>> build() async {
    return accountsRepository.getAll();
  }

  Future<void> getWithQuery(String query) async {
    state = AsyncValue.data(await accountsRepository.getAll(query));
  }

  Future<void> addAccountAccess(AccountInfo account, AccountAccess access) async {
    try {
      await accountsRepository.addAccess(account.login, access);
      final newAccount = AccountInfo(
        login: account.login,
        fullName: account.fullName,
        accesses: [...account.accesses, access],
      );
      state = AsyncValue.data((state.value ?? []).map((e) {
        if (e.login == account.login) {
          return newAccount;
        }
        return e;
      }).toList());
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }

  Future<void> deleteAccountAccess(AccountInfo account, AccountAccess access) async {
    try {
      await accountsRepository.deleteAccess(account.login, access);
      final newAccount = AccountInfo(
        login: account.login,
        fullName: account.fullName,
        accesses: account.accesses.where((a) => a != access).toList(),
      );
      state = AsyncValue.data((state.value ?? []).map((e) {
        if (e.login == account.login) {
          return newAccount;
        }
        return e;
      }).toList());
    } catch (e) {
      if (e is BackendException) {
        ref.read(exceptionProvider.notifier).state = e;
      }
    }
  }
}

final accountsProvider =
    AutoDisposeAsyncNotifierProvider<AccountsNotifier, List<AccountInfo>>(
        AccountsNotifier.new);
