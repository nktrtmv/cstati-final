import 'package:event_flow/domain/repository/accounts_repository.dart';
import 'package:event_flow/internal/dependencies/repository_module.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:shared_preferences/shared_preferences.dart';

class AuthController with ChangeNotifier {
  bool isLoggedIn = false;
  String? userLogin;
  final AccountsRepository accountsRepository = RepositoryModule.accountsRepository();

  void register(String login, String password, String fullName) async {
    await accountsRepository.create(login, password, fullName);
    await (manualSignIn(login, password));
    signIn();
  }

  void signIn() {
    isLoggedIn = true;
    notifyListeners();
  }

  Future<bool> manualSignIn(String login, String password) async {
    bool success = await accountsRepository.authorize(login, password);
    if (success) {
      userLogin = login;
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      await prefs.setString(Strings.sessionKey, '$login-$password');
      signIn();
    }
    return success;
  }

  void autoSignIn() async {
    final SharedPreferences prefs = await SharedPreferences.getInstance();
    final String? sessionToken = prefs.getString(Strings.sessionKey);
    if (sessionToken != null) {
      try {
        String login = sessionToken.split('-').first;
        String password = sessionToken.split('-').last;
        bool success = await accountsRepository.authorize(login, password);
        if (success) {
          userLogin = login;
          signIn();
        }
      } catch (_) {}
    }
  }

  void signOut() async {
    final SharedPreferences prefs = await SharedPreferences.getInstance();
    await prefs.remove(Strings.sessionKey);
    userLogin = null;
    isLoggedIn = false;
    notifyListeners();
  }
}

final authProvider = ChangeNotifierProvider((ref) => AuthController());
