import 'package:event_flow/domain/model/account_info.dart';
import 'package:event_flow/domain/model/enums/payment_bank.dart';
import 'package:event_flow/domain/model/payment_collector.dart';
import 'package:event_flow/domain/state/accounts_state.dart';
import 'package:event_flow/domain/state/event_collectors_state.dart';
import 'package:event_flow/presentation/widgets/account_search_widget.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class CreateEditCollectorDialog extends ConsumerStatefulWidget {
  final PaymentCollector? collector;
  final String eventId;

  const CreateEditCollectorDialog(
      {super.key, required this.eventId, this.collector});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() =>
      _CreateEditCollectorDialogState();
}

class _CreateEditCollectorDialogState
    extends ConsumerState<CreateEditCollectorDialog> {
  final _formKey = GlobalKey<FormState>();
  final _phoneController = TextEditingController();
  final _cardController = TextEditingController();
  String? _selectedLogin;
  PaymentBank? _selectedBank;
  String? _errorText;

  @override
  void initState() {
    super.initState();
    _phoneController.text = widget.collector?.phone ?? '';
    _cardController.text = widget.collector?.cardNumber ?? '';
    _selectedBank = widget.collector?.bank;
    if (widget.collector != null) {
      _selectedLogin = widget.collector!.person.login;
    }
  }

  @override
  void dispose() {
    _phoneController.dispose();
    _cardController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text(Strings.tooltipAddCollector),
      content: Container(
        width: 600,
        child: Form(
          key: _formKey,
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              AccountSearchWidget(
                errorText: _errorText,
                onSelect: (value) {
                  setState(() {
                    _selectedLogin = value;
                  });
                },
              ),
              const SizedBox(
                height: 16,
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  const Text(Strings.bank),
                  SizedBox(
                    width: 300,
                    child: DropdownButtonFormField(
                      value: _selectedBank,
                      items: PaymentBank.values
                          .map((e) => DropdownMenuItem(
                              value: e, child: Text(Strings.getPaymentBank(e))))
                          .toList(),
                      onChanged: (value) {
                        if (value != null) {
                          _selectedBank = value;
                        }
                      },
                      validator: (value) {
                        if (value == null || value == PaymentBank.none) {
                          return Strings.errorTextField;
                        }
                        return null;
                      },
                    ),
                  ),
                ],
              ),
              const SizedBox(
                height: 16,
              ),
              TextFormField(
                decoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: Strings.tableColPhone,
                ),
                controller: _phoneController,
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
                  labelText: Strings.card,
                ),
                controller: _cardController,
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
              if (_formKey.currentState!.validate()) {
                if (_selectedLogin != null) {
                  if (widget.collector == null) {
                    ref
                        .read(eventCollectorsProvider(widget.eventId).notifier)
                        .add(
                      _selectedLogin!,
                      _selectedBank!,
                      _phoneController.text,
                      _cardController.text,
                    );
                  } else {
                    ref
                        .read(eventCollectorsProvider(widget.eventId).notifier)
                        .updateCollector(
                      PaymentCollector(
                        person: AccountInfo(
                          login: _selectedLogin!,
                          fullName: "",
                          accesses: [],
                        ),
                        bank: _selectedBank!,
                        phone: _phoneController.text,
                        cardNumber: _cardController.text,
                        guests: widget.collector!.guests,
                      ),
                    );
                  }
                  Navigator.of(context).pop();
                } else {
                  setState(() {
                    _errorText = Strings.errorTextField;
                  });
                }
              }
            },
            child:
                Text(widget.collector == null ? Strings.create : Strings.save)),
      ],
    );
  }
}
