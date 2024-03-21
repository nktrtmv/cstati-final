import 'package:event_flow/domain/model/enums/ticket_type.dart';
import 'package:event_flow/domain/model/enums/wave_status.dart';
import 'package:event_flow/domain/model/event_ticket.dart';
import 'package:event_flow/domain/state/event_tickets_state.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class EventTicketsWidget extends ConsumerStatefulWidget {
  final String eventId;
  final int waveOrdinal;
  final EventWaveStatus status;

  const EventTicketsWidget({
    super.key,
    required this.eventId,
    required this.waveOrdinal,
    required this.status,
  });

  @override
  ConsumerState<ConsumerStatefulWidget> createState() =>
      _EventTicketsWidgetState();
}

class _EventTicketsWidgetState extends ConsumerState<EventTicketsWidget> {
  final _addTicketFormKey = GlobalKey<FormState>();
  TicketType selectedType = TicketType.standard;
  final _priceController = TextEditingController();

  @override
  void dispose() {
    _priceController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final ticketsFuture = ref.watch(
        eventTicketsProvider(UniqueWave(widget.eventId, widget.waveOrdinal)));
    return ticketsFuture.when(
      data: (tickets) {
        return Wrap(
          alignment: WrapAlignment.start,
          spacing: 16.0,
          runSpacing: 16.0,
          children: [
            ...tickets
                .map(
                  (ticket) => Card(
                    color: Theme.of(context).colorScheme.surface,
                    surfaceTintColor: Colors.black,
                    child: SizedBox(
                      height: 200,
                      width: 300,
                      child: Padding(
                        padding: const EdgeInsets.all(16.0),
                        child: Column(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          children: [
                            Text(
                              Strings.getEventTicketType(ticket.type),
                              style: Theme.of(context).textTheme.displaySmall,
                            ),
                            Row(
                              mainAxisAlignment: MainAxisAlignment.center,
                              children: [
                                Text(
                                  "${ticket.price}",
                                  style:
                                      Theme.of(context).textTheme.displaySmall,
                                ),
                                const Icon(Icons.currency_ruble),
                              ],
                            ),

                              Row(
                                mainAxisAlignment: MainAxisAlignment.end,
                                children: [
                                  if (widget.status == EventWaveStatus.notStarted) ElevatedButton(
                                    onPressed: () {
                                      ref
                                          .read(eventTicketsProvider(UniqueWave(
                                                  widget.eventId,
                                                  widget.waveOrdinal))
                                              .notifier)
                                          .delete(ticket);
                                    },
                                    child: const Text(
                                      Strings.deleteTicket,
                                      style: TextStyle(color: Colors.redAccent),
                                    ),
                                  ),
                                ],
                              )
                          ],
                        ),
                      ),
                    ),
                  ),
                )
                .toList(),
            Card(
              color: Theme.of(context).colorScheme.surface,
              surfaceTintColor: Colors.black,
              child: SizedBox(
                height: 200,
                width: 300,
                child: Padding(
                  padding: const EdgeInsets.all(16.0),
                  child: Form(
                    key: _addTicketFormKey,
                    child: Column(
                      children: [
                        Wrap(
                          children: [
                            ChoiceChip(
                              label: Text(Strings.getEventTicketType(
                                  TicketType.standard)),
                              selected: selectedType == TicketType.standard,
                              onSelected: (value) {
                                setState(() {
                                  if (value) {
                                    selectedType = TicketType.standard;
                                  }
                                });
                              },
                            ),
                            const SizedBox(width: 8),
                            ChoiceChip(
                              label: Text(Strings.getEventTicketType(
                                  TicketType.comfort)),
                              selected: selectedType == TicketType.comfort,
                              onSelected: (value) {
                                setState(() {
                                  if (value) {
                                    selectedType = TicketType.comfort;
                                  }
                                });
                              },
                            ),
                          ],
                        ),
                        const SizedBox(
                          height: 16,
                        ),
                        TextFormField(
                          controller: _priceController,
                          validator: (value) {
                            if (value == null) {
                              return Strings.errorTextField;
                            } else if (value.isEmpty) {
                              return Strings.errorTextField;
                            } else if (double.tryParse(value) == null) {
                              return Strings.errorTextFieldDouble;
                            } else if (double.parse(value) <= 0) {
                              return Strings.errorTextFieldDouble;
                            } else {
                              return null;
                            }
                          },
                          style: const TextStyle(fontSize: 16),
                          decoration: const InputDecoration(
                            labelText: Strings.price,
                            suffixIcon: Icon(Icons.currency_ruble),
                          ),
                        ),
                        const Spacer(),
                        Row(
                          mainAxisAlignment: MainAxisAlignment.end,
                          children: [
                            ElevatedButton(
                                onPressed: widget.status ==
                                        EventWaveStatus.notStarted
                                    ? () {
                                        if (_addTicketFormKey.currentState!
                                            .validate()) {
                                          double ticketPrice = double.tryParse(
                                                  _priceController.text) ??
                                              0;
                                          _priceController.clear();
                                          ref
                                              .read(eventTicketsProvider(
                                                      UniqueWave(widget.eventId,
                                                          widget.waveOrdinal))
                                                  .notifier)
                                              .add(selectedType, ticketPrice);
                                          selectedType = TicketType.standard;
                                        }
                                      }
                                    : null,
                                child: const Text(Strings.tooltipAddTicket)),
                          ],
                        ),
                      ],
                    ),
                  ),
                ),
              ),
            ),
          ],
        );
      },
      error: (err, trace) => const Text(Strings.error),
      loading: () => const CircularProgressIndicator(),
    );
  }
}
