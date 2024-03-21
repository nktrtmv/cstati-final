import 'package:event_flow/domain/model/account_info.dart';
import 'package:event_flow/domain/state/event_finances_state.dart';
import 'package:event_flow/presentation/widgets/account_search_widget.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class CreateExpenseDialog extends ConsumerStatefulWidget {
  final String eventId;

  const CreateExpenseDialog({super.key, required this.eventId});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() =>
      _CreateExpenseDialogState();
}

class _CreateExpenseDialogState extends ConsumerState<CreateExpenseDialog> {
  AccountInfo? selectedInfo;
  final _createExpenseFormKey = GlobalKey<FormState>();
  final _descriptionController = TextEditingController();
  final _priceController = TextEditingController();
  final _marketController = TextEditingController();
  String? _login;
  String? _errorText;

  @override
  void dispose() {
    _priceController.dispose();
    _marketController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text(Strings.tooltipAddExpense),
      content: Container(
        width: 600,
        child: Form(
          key: _createExpenseFormKey,
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              AccountSearchWidget(
                errorText: _errorText,
                onSelect: (value) {
                  setState(() {
                    _login = value;
                  });
                },
              ),
              const SizedBox(
                height: 16,
              ),
              TextFormField(
                decoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: Strings.price,
                ),
                controller: _priceController,
                keyboardType: const TextInputType.numberWithOptions(
                    signed: false, decimal: true),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return Strings.errorTextField;
                  }
                  if (double.tryParse(value) == null) {
                    return Strings.errorTextFieldDouble;
                  }
                  if (double.parse(value) <= 0) {
                    return Strings.errorTextFieldDouble;
                  }
                  return null;
                },
              ),
              const SizedBox(
                height: 16,
              ),
              TextFormField(
                decoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: Strings.market,
                ),
                controller: _marketController,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return Strings.errorTextField;
                  }
                  return null;
                },
              ),
              const SizedBox(
                height: 16,
              ),
              TextFormField(
                decoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: Strings.description,
                ),
                minLines: 3,
                maxLines: null,
                controller: _descriptionController,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return Strings.errorTextField;
                  }
                  return null;
                },
              ),
              const SizedBox(
                height: 16,
              ),
            ],
          ),
        ),
      ),
      actions: [
        TextButton(
          onPressed: () {
            Navigator.of(context).pop();
          },
          child: const Text(Strings.cancel),
        ),
        TextButton(
          onPressed: () {
            if (_createExpenseFormKey.currentState!.validate()) {
              if (_login != null) {
                ref.read(eventFinanceProvider(widget.eventId).notifier).add(
                  _login!,
                  _descriptionController.text,
                  double.parse(_priceController.text),
                  _marketController.text,
                );
                Navigator.of(context).pop();
              } else {
                setState(() {
                  _errorText = Strings.errorTextField;
                });
              }
            }
          },
          child: const Text(Strings.create),
        ),
      ],
    );
  }
}
