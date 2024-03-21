import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';

class PasswordInput extends StatefulWidget {
  final TextEditingController controller;
  final String? Function(String?) validator;
  final String hintText;
  final String? errorText;
  const PasswordInput({
    super.key,
    required this.controller,
    required this.validator,
    required this.hintText,
    required this.errorText,
  });

  @override
  State<StatefulWidget> createState() => _PasswordInputState();
}

class _PasswordInputState extends State<PasswordInput> {
  bool _obscurePassword = true;
  @override
  Widget build(BuildContext context) {
    return TextFormField(
      decoration: InputDecoration(
          suffixIcon: IconButton(
            onPressed: () {
              setState(() {
                _obscurePassword =
                !_obscurePassword;
              });
            },
            hoverColor: Colors.transparent,
            icon: Icon(
              _obscurePassword
                  ? Icons.visibility
                  : Icons.visibility_off,
            ),
          ),
          border: const OutlineInputBorder(),
          hintText: widget.hintText,
          errorText: widget.errorText,
      ),
      controller: widget.controller,
      keyboardType: TextInputType.visiblePassword,
      obscureText: _obscurePassword,
      enableSuggestions: false,
      autocorrect: false,
      validator: widget.validator,
    );
  }
}