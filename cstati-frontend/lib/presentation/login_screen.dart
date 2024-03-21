import 'package:event_flow/domain/state/auth_state.dart';
import 'package:event_flow/presentation/widgets/password_input.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';

class LoginScreen extends ConsumerStatefulWidget {
  const LoginScreen({super.key});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() => _LoginScreenState();
}

class _LoginScreenState extends ConsumerState<LoginScreen> {
  final _loginController = TextEditingController();
  final _passwordController = TextEditingController();
  final _authFormKey = GlobalKey<FormState>();
  String _errorMessage = '';

  @override
  void dispose() {
    _loginController.dispose();
    _passwordController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Container(
              decoration: BoxDecoration(
                color: Theme.of(context).colorScheme.surface,
                borderRadius: BorderRadius.circular(12),
              ),
              padding: EdgeInsets.symmetric(horizontal: 64, vertical: 32),
              width: 500,
              child: Form(
                key: _authFormKey,
                child: Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.symmetric(vertical: 8.0),
                      child: Text(
                        Strings.login,
                        style: Theme.of(context).textTheme.displaySmall,
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(vertical: 8.0),
                      child: TextFormField(
                        controller: _loginController,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return Strings.errorTextField;
                          }
                          return null;
                        },
                        decoration: InputDecoration(
                            border: const OutlineInputBorder(),
                            hintText: Strings.loginFormEnterLogin,
                            errorText: _errorMessage.isNotEmpty ? _errorMessage : null,
                        ),
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(vertical: 8.0),
                      child: PasswordInput(
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return Strings.errorTextField;
                          }
                          return null;
                        },
                        controller: _passwordController,
                        hintText: Strings.loginFormEnterPassword,
                        errorText: _errorMessage.isNotEmpty ? _errorMessage : null,
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(vertical: 8.0),
                      child: ElevatedButton(
                        style: ElevatedButton.styleFrom(
                          minimumSize: const Size.fromHeight(60),
                        ),
                        onPressed: () async {
                          if (_authFormKey.currentState!.validate()) {
                            String login = _loginController.text;
                            String password = _passwordController.text;
                            final success = await ref
                                .read(authProvider.notifier)
                                .manualSignIn(login, password);
                            if (!success) {
                              setState(() {
                                _errorMessage = Strings.errorTextFieldData;
                              });
                            }
                          }
                        },
                        child: const Text(Strings.loginFormEnter),
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(vertical: 8.0),
                      child: RichText(
                        text: TextSpan(
                          style: Theme.of(context).textTheme.bodySmall,
                          children: [
                            const TextSpan(text: "${Strings.noAccount} "),
                            TextSpan(
                              text: Strings.loginFormRegister,
                              style: const TextStyle(color: Colors.lightBlue),
                              recognizer: TapGestureRecognizer()
                                ..onTap = () {
                                  context
                                      .push(Uri(path: '/register').toString());
                                },
                            ),
                          ],
                        ),
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
