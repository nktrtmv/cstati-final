import 'package:event_flow/domain/model/enums/payment_status.dart';
import 'package:event_flow/domain/repository/guests_repository.dart';
import 'package:event_flow/internal/dependencies/repository_module.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';


final selectStatusProvider = StateProvider<List<PaymentStatus>>((ref) => []);

class SendMessageDialog extends ConsumerStatefulWidget {
  final String eventId;

  const SendMessageDialog({super.key, required this.eventId});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() =>
      _SendMessageDialogState();
}

class _SendMessageDialogState extends ConsumerState<SendMessageDialog> {
  final _messageController = TextEditingController();
  final _formKey = GlobalKey<FormState>();

  @override
  void dispose() {
    _messageController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final selectedStatuses = ref.watch(selectStatusProvider);
    print(selectedStatuses);
    return AlertDialog(
      title: Text(Strings.sendMessage,
          style: Theme.of(context).textTheme.displaySmall),
      content: Container(
        width: 800,
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Form(
            key: _formKey,
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                TextFormField(
                  controller: _messageController,
                  maxLines: 5,
                  minLines: 5,
                  decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: Strings.message,
                  ),
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
                Wrap(
                  spacing: 8.0,
                  runSpacing: 8.0,
                  children: PaymentStatus.values.skip(1)
                      .map(
                        (status) => FilterChip(
                          label: Text(Strings.getPaymentStatus(status)),
                          selected: selectedStatuses.contains(status),
                          onSelected: (value) {
                            if (value) {
                              ref.read(selectStatusProvider.notifier).state = [...ref.read(selectStatusProvider), status];
                            } else {
                              ref.read(selectStatusProvider.notifier).state = ref.read(selectStatusProvider).where((s) => s != status).toList();
                            }
                          },
                        ),
                      )
                      .toList(),
                ),
                const SizedBox(
                  height: 16,
                ),
              ],
            ),
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
              final GuestsRepository guestsRepository =
              RepositoryModule.guestsRepository();
              guestsRepository.sendTelegramMessages(
                  widget.eventId, selectedStatuses, _messageController.text);
              context.pop();
            }
          },
          child: const Row(
            mainAxisSize: MainAxisSize.min,
            children: [
              Icon(Icons.send),
              SizedBox(
                width: 8,
              ),
              Text(Strings.send),
            ],
          ),
        ),
      ],
    );
  }
}
