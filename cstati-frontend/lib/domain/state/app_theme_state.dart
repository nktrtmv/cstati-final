import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:shared_preferences/shared_preferences.dart';

class ThemeController extends Notifier<ThemeMode>{
  Future<void> setDarkMode() async {
    final SharedPreferences prefs = await SharedPreferences.getInstance();
    await prefs.setString(Strings.themeKey, ThemeMode.dark.name);
    ref.invalidateSelf();
  }

  Future<void> setLightMode() async {
    final SharedPreferences prefs = await SharedPreferences.getInstance();
    await prefs.setString(Strings.themeKey, ThemeMode.dark.name);
    ref.invalidateSelf();
  }

  @override
  ThemeMode build() {
    // final SharedPreferences prefs = await SharedPreferences.getInstance();
    // String theme = prefs.getString(Strings.themeKey) ?? "light";
    // ThemeMode mode = ThemeMode.values.byName(theme);
    return ThemeMode.dark;
  }
}

final appThemeProvider = NotifierProvider<ThemeController, ThemeMode>(ThemeController.new);