import 'package:event_flow/domain/model/enums/payment_status.dart';
import 'package:event_flow/domain/repository/guests_repository.dart';
import 'package:event_flow/internal/dependencies/repository_module.dart';
import 'package:event_flow/presentation/dialogs/select_datetime_dialog.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';
import 'package:intl/intl.dart';

class SendDeadlineMessageDialog extends ConsumerStatefulWidget {
  final String eventId;

  const SendDeadlineMessageDialog({super.key, required this.eventId});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() =>
      _SendDeadlineMessageDialogState();
}

class _SendDeadlineMessageDialogState extends ConsumerState<SendDeadlineMessageDialog> {
  final _messageController = TextEditingController();
  final _dateController = TextEditingController();
  final _formKey = GlobalKey<FormState>();
  DateTime deadline = DateTime.now();

  @override
  void dispose() {
    _messageController.dispose();
    _dateController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
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
                  decoration: const InputDecoration(
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
                TextFormField(
                  controller: _dateController,
                  readOnly: true,
                  onTap: () async {
                    DateTime? date = await selectDateTime(context, DateTime.now());
                    if (date != null) {
                      _dateController.text = DateFormat('dd.MM.yyyy – kk:mm').format(date);
                      deadline = date;
                    }
                  },
                  decoration: const InputDecoration(
                    border: OutlineInputBorder(),
                    hintText: Strings.eventSelectTime,
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
              guestsRepository.sendTelegramPaymentMessages(
                  widget.eventId, _messageController.text, deadline);
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
