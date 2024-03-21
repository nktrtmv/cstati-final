import 'package:event_flow/domain/state/auth_state.dart';
import 'package:event_flow/presentation/event_screen.dart';
import 'package:event_flow/presentation/login_screen.dart';
import 'package:event_flow/presentation/main_screen.dart';
import 'package:event_flow/presentation/no_event_screen.dart';
import 'package:event_flow/presentation/register_screen.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';

final _routerKey = GlobalKey<NavigatorState>();

enum AppRoute { login, register, event, home }

final routerProvider = Provider((ref) {
  final authState = ref.watch(authProvider);
  return GoRouter(
    navigatorKey: _routerKey,
    initialLocation: '/',
    refreshListenable: authState,
    routes: [
      GoRoute(
        path: '/',
        name: AppRoute.home.name,
        builder: (context, state) => const MainScreen(),
      ),
      GoRoute(
        path: '/${AppRoute.login.name}',
        name: AppRoute.login.name,
        builder: (context, state) => const LoginScreen(),
      ),
      GoRoute(
        path: '/${AppRoute.register.name}',
        name: AppRoute.register.name,
        builder: (context, state) => const RegisterScreen(),
      ),
      GoRoute(
        path: '/${AppRoute.event.name}',
        name: AppRoute.event.name,
        builder: (context, state) {
          if (state.uri.queryParameters.containsKey('id')) {
            return EventScreen(eventId: state.uri.queryParameters['id']!);
          } else {
            return const NoEventScreen();
          }
        },
      ),
    ],
    redirect: (context, state) async {
      final isAuthenticated = authState.isLoggedIn;
      if (!isAuthenticated) {
        authState.autoSignIn();
      }
      if (!isAuthenticated && state.fullPath != null && state.fullPath != "/${AppRoute.register.name}") {
        return "/${AppRoute.login.name}";
      }
      return null;
    }
  );
});
