import 'package:event_flow/domain/state/events_screen_state.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';

class CreateEventDialog extends ConsumerStatefulWidget {
  const CreateEventDialog({super.key});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() =>
      _CreateEventDialogState();
}

class _CreateEventDialogState extends ConsumerState<CreateEventDialog> {
  final _nameController = TextEditingController();
  final _formKey = GlobalKey<FormState>();

  @override
  void dispose() {
    _nameController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: 600,
      height: 300,
      child: AlertDialog(
        title: const Text(Strings.createEvent),
        content: Form(
          key: _formKey,
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              TextFormField(
                controller: _nameController,
                decoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: Strings.eventEditName,
                ),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return Strings.errorTextField;
                  }
                  return null;
                },
              ),
            ],
          ),
        ),
        actions: [
          TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: const Text(Strings.cancel)),
          TextButton(
              onPressed: () async {
                if (_formKey.currentState!.validate()) {
                  String eventId = await ref
                      .read(eventsProvider.notifier)
                      .addEvent(_nameController.text);
                  if (context.mounted) {
                    Navigator.of(context).pop();
                    context.push(
                        Uri(path: '/event', queryParameters: {'id': eventId})
                            .toString());
                  }
                }
              },
              child: const Text(Strings.create)),
        ],
      ),
    );
  }
}
