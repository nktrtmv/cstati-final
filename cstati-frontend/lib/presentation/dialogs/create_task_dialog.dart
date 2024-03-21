import 'package:event_flow/domain/state/event_tasks_state.dart';
import 'package:event_flow/presentation/dialogs/select_datetime_dialog.dart';
import 'package:event_flow/presentation/widgets/account_search_widget.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:intl/intl.dart';

class CreateTaskDialog extends ConsumerStatefulWidget {
  final String eventId;

  const CreateTaskDialog({super.key, required this.eventId});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() =>
      _CreateTaskDialogState();
}

class _CreateTaskDialogState extends ConsumerState<CreateTaskDialog> {
  final nameController = TextEditingController();
  final descriptionController = TextEditingController();
  final _dateController = TextEditingController();
  final addTaskFormKey = GlobalKey<FormState>();
  DateTime deadline = DateTime.now();
  String? login;
  String? _errorText;

  @override
  void dispose() {
    nameController.dispose();
    descriptionController.dispose();
    _dateController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text(Strings.eventTaskNew),
      content: SizedBox(
        width: 600,
        child: Form(
          key: addTaskFormKey,
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: TextFormField(
                  controller: nameController,
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return Strings.errorTextField;
                    }
                    return null;
                  },
                  decoration: const InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: Strings.eventTaskName,
                  ),
                ),
              ),
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: AccountSearchWidget(
                  errorText: _errorText,
                  onSelect: (value) {
                    setState(() {
                      login = value;
                    });
                  },
                ),
              ),
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: TextFormField(
                  controller: descriptionController,
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return Strings.errorTextField;
                    }
                    return null;
                  },
                  decoration: const InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: Strings.eventTaskDesc,
                  ),
                  minLines: 3,
                  maxLines: 3,
                  keyboardType: TextInputType.multiline,
                ),
              ),
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: TextFormField(
                  controller: _dateController,
                  readOnly: true,
                  onTap: () async {
                    DateTime? date =
                        await selectDateTime(context, DateTime.now());
                    if (date != null) {
                      _dateController.text =
                          DateFormat('dd.MM.yyyy – kk:mm').format(date);
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
            child: const Text(Strings.cancel)),
        TextButton(
            onPressed: () {
              if (addTaskFormKey.currentState!.validate()) {
                if (login != null) {
                  String name = nameController.text;
                  String person = login!;
                  String description = descriptionController.text;
                  ref
                      .read(eventTasksProvider(widget.eventId).notifier)
                      .add(name, person, description, deadline);
                  Navigator.of(context).pop();
                } else {
                  setState(() {
                    _errorText = Strings.errorTextField;
                  });
                }

              }
            },
            child: const Text(Strings.create)),
      ],
    );
  }
}
