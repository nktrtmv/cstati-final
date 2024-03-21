import 'package:event_flow/domain/model/enums/payment_status.dart';
import 'package:event_flow/domain/repository/guests_repository.dart';
import 'package:event_flow/internal/dependencies/repository_module.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class TelegramBotScreen extends ConsumerStatefulWidget {
  final String eventId;
  const TelegramBotScreen({super.key, required this.eventId});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() => _TelegramBotState();
}

class _TelegramBotState extends ConsumerState<TelegramBotScreen> {
  final _messageController = TextEditingController();
  PaymentStatus _selectedStatus = PaymentStatus.none;

  @override
  void dispose() {
    _messageController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Container(
        constraints: const BoxConstraints(maxWidth: 800),
        child: Card(
          child: Padding(
            padding: const EdgeInsets.all(16.0),
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                Text(
                  Strings.sendMessage,
                  style: Theme.of(context).textTheme.displaySmall,
                ),
                const SizedBox(
                  height: 16,
                ),
                TextField(
                  controller: _messageController,
                  maxLines: 5,
                  minLines: 5,
                  decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: Strings.message,
                  ),
                ),
                const SizedBox(
                  height: 16,
                ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Text(Strings.selectStatus),
                    DropdownMenu(
                      initialSelection: PaymentStatus.none,
                      dropdownMenuEntries: PaymentStatus.values
                          .map((e) => DropdownMenuEntry(
                              value: e, label: Strings.getPaymentStatus(e)))
                          .toList(),
                    ),
                  ],
                ),
                const SizedBox(
                  height: 16,
                ),
                ElevatedButton(
                    onPressed: () {
                      final GuestsRepository guestsRepository = RepositoryModule.guestsRepository();
                      guestsRepository.sendTelegramMessages(widget.eventId, [], _messageController.text);
                    },
                    child: const Row(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        Icon(Icons.send),
                        SizedBox(
                          width: 16,
                        ),
                        Text(Strings.send),
                      ],
                    ))
              ],
            ),
          ),
        ),
      ),
    );
  }
}
