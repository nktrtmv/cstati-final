import 'package:event_flow/domain/state/auth_state.dart';
import 'package:event_flow/presentation/widgets/password_input.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';

class RegisterScreen extends ConsumerStatefulWidget {
  const RegisterScreen({super.key});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() => _RegisterScreenState();
}

class _RegisterScreenState extends ConsumerState<RegisterScreen> {
  final _loginController = TextEditingController();
  final _passwordController = TextEditingController();
  final _passwordCheckController = TextEditingController();
  final _nameController = TextEditingController();
  final _authFormKey = GlobalKey<FormState>();

  @override
  void dispose() {
    _loginController.dispose();
    _passwordController.dispose();
    _passwordCheckController.dispose();
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
                        Strings.register,
                        style: Theme.of(context).textTheme.displaySmall,
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(vertical: 8.0),
                      child: TextFormField(
                        controller: _nameController,
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return Strings.errorTextField;
                          }
                          return null;
                        },
                        decoration: const InputDecoration(
                            border: OutlineInputBorder(),
                            hintText: Strings.loginFormName),
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
                        decoration: const InputDecoration(
                            border: OutlineInputBorder(),
                            hintText: Strings.loginFormEnterLogin),
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(vertical: 8.0),
                      child: PasswordInput(
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return Strings.errorTextField;
                          }
                          if (value != _passwordCheckController.text) {
                            return Strings.errorTextFieldPasswordMismatch;
                          }
                          return null;
                        },
                        controller: _passwordController,
                        hintText: Strings.loginFormEnterPassword,
                        errorText: null,
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(vertical: 8.0),
                      child: PasswordInput(
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return Strings.errorTextField;
                          }
                          if (value != _passwordController.text) {
                            return Strings.errorTextFieldPasswordMismatch;
                          }
                          return null;
                        },
                        controller: _passwordCheckController,
                        hintText: Strings.loginFormCheckPassword,
                        errorText: null,
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(vertical: 8.0),
                      child: ElevatedButton(
                        style: ElevatedButton.styleFrom(
                          minimumSize: const Size.fromHeight(60),
                        ),
                        onPressed: () {
                          if (_authFormKey.currentState!.validate()) {
                            ref.read(authProvider.notifier).register(
                              _loginController.text,
                              _passwordController.text,
                              _nameController.text,
                            );
                          }
                        },
                        child: const Text(Strings.loginFormRegister),
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(vertical: 8.0),
                      child: RichText(
                        text: TextSpan(
                          style: Theme.of(context).textTheme.bodySmall,
                          children: [
                            const TextSpan(text: "${Strings.haveAccount} "),
                            TextSpan(
                              text: Strings.registerFormLogin,
                              style: const TextStyle(color: Colors.lightBlue),
                              recognizer: TapGestureRecognizer()
                                ..onTap = () {
                                  context.push(Uri(path: '/login').toString());
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
