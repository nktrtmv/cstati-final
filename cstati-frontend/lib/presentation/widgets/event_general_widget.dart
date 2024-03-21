import 'package:event_flow/domain/model/enums/event_status.dart';
import 'package:event_flow/domain/model/event.dart';
import 'package:event_flow/domain/model/event_expense.dart';
import 'package:event_flow/domain/state/event_screen_state.dart';
import 'package:event_flow/domain/state/events_screen_state.dart';
import 'package:event_flow/presentation/dialogs/select_datetime_dialog.dart';
import 'package:event_flow/presentation/event_edit_screen.dart';
import 'package:event_flow/presentation/widgets/event_status_chip.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:intl/intl.dart';
import 'package:url_launcher/url_launcher.dart';

final copyButtonProvider = StateProvider<Icon>((ref) => const Icon(
      Icons.numbers,
      color: Colors.blueAccent,
    ));

class EventGeneral extends ConsumerStatefulWidget {
  final Event event;

  const EventGeneral({super.key, required this.event});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() => _EventGeneralState();
}

class _EventGeneralState extends ConsumerState<EventGeneral> {
  final _locationController = TextEditingController();
  final _dateController = TextEditingController();
  final _guestsCountController = TextEditingController();
  final _excelLinkController = TextEditingController();
  DateTime? eventDateTime;
  String? _errorMessage;
  bool _success = false;
  bool _isEdited = false;

  @override
  void dispose() {
    _locationController.dispose();
    _dateController.dispose();
    _guestsCountController.dispose();
    _excelLinkController.dispose();
    super.dispose();
  }

  @override
  void initState() {
    if (widget.event.expectedGuestsCount != null) {
      _guestsCountController.text = widget.event.expectedGuestsCount.toString();
    }
    if (widget.event.date != null) {
      _dateController.text =
          DateFormat('dd.MM.yyyy – kk:mm').format(widget.event.date!);
    }
    if (widget.event.location != null) {
      _locationController.text = widget.event.location!;
    }
    if (widget.event.excelLink != null) {
      _excelLinkController.text = widget.event.excelLink!;
    }
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    final copyIcon = ref.watch(copyButtonProvider);
    final event = widget.event;
    return SingleChildScrollView(
      child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Container(
            constraints: const BoxConstraints(
              maxHeight: 600,
            ),
            child: Card(
              child: Padding(
                padding: const EdgeInsets.all(32.0),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Row(
                      mainAxisAlignment: MainAxisAlignment.start,
                      children: [
                        Text(
                          event.name,
                          style: TextStyle(fontSize: 60),
                        ),
                        const Spacer(),
                        EventStatusChip(status: widget.event.status),
                        if (widget.event.status.index <
                            EventStatus.values.length - 1)
                          PopupMenuButton(
                            itemBuilder: (context) => [
                              PopupMenuItem(
                                value: EventStatus
                                    .values[widget.event.status.index + 1],
                                child: Text(
                                    "Перейти к ${Strings.getEventStatus(EventStatus.values[widget.event.status.index + 1])}"),
                              ),
                            ],
                            onSelected: (value) {
                              ref
                                  .read(eventProvider(widget.event.id).notifier)
                                  .updateEvent(
                                      widget.event.copyWith(status: value));
                            },
                          ),
                      ],
                    ),
                    const SizedBox(
                      height: 32,
                    ),
                    Row(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Expanded(
                          flex: 3,
                          child: Column(
                            mainAxisAlignment: MainAxisAlignment.start,
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Text(Strings.eventEditTime,
                                  style: Theme.of(context)
                                      .textTheme
                                      .headlineMedium),
                              const SizedBox(
                                height: 43,
                              ),
                              Text(Strings.eventEditLocation,
                                  style: Theme.of(context)
                                      .textTheme
                                      .headlineMedium),
                              const SizedBox(
                                height: 43,
                              ),
                              Text(Strings.expectedGuestsCount,
                                  style: Theme.of(context)
                                      .textTheme
                                      .headlineMedium),
                              const SizedBox(
                                height: 43,
                              ),
                              Text(
                                Strings.tooltipExcel,
                                style:
                                    Theme.of(context).textTheme.headlineMedium,
                              ),
                            ],
                          ),
                        ),
                        Expanded(
                          flex: 3,
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              TextFormField(
                                controller: _dateController,
                                readOnly: true,
                                decoration: const InputDecoration(
                                  border: OutlineInputBorder(),
                                  hintText: Strings.eventSelectDate,
                                  contentPadding: EdgeInsets.only(left: 16),
                                ),
                                onTap: () async {
                                  DateTime? date = await selectDateTime(
                                      context, DateTime.now());
                                  if (date != null) {
                                    setState(() {
                                      _isEdited = true;
                                      _dateController.text =
                                          DateFormat('dd.MM.yyyy – kk:mm')
                                              .format(date);
                                      eventDateTime = date;
                                    });
                                  }
                                },
                              ),
                              const SizedBox(
                                height: 30,
                              ),
                              TextFormField(
                                controller: _locationController,
                                decoration: const InputDecoration(
                                  border: OutlineInputBorder(),
                                  hintText: Strings.eventEditLocation,
                                  contentPadding: EdgeInsets.only(left: 16),
                                ),
                                onChanged: (_) {
                                  setState(() {
                                    _isEdited = true;
                                  });
                                },
                              ),
                              const SizedBox(
                                height: 30,
                              ),
                              TextFormField(
                                controller: _guestsCountController,
                                keyboardType: TextInputType.number,
                                decoration: InputDecoration(
                                  border: const OutlineInputBorder(),
                                  hintText: Strings.expectedGuestsCount,
                                  contentPadding:
                                      const EdgeInsets.only(left: 16),
                                  errorText: _errorMessage,
                                ),
                                onChanged: (_) {
                                  setState(() {
                                    _isEdited = true;
                                  });
                                },
                              ),
                              const SizedBox(
                                height: 30,
                              ),
                              TextFormField(
                                controller: _excelLinkController,
                                decoration: const InputDecoration(
                                  border: OutlineInputBorder(),
                                  hintText: Strings.tooltipExcel,
                                  contentPadding: EdgeInsets.only(left: 16),
                                ),
                                onChanged: (_) {
                                  setState(() {
                                    _isEdited = true;
                                  });
                                },
                              ),
                            ],
                          ),
                        ),
                        Expanded(
                          flex: 3,
                          child: Container(),
                        ),
                      ],
                    ),
                    const Spacer(),
                    Row(
                      children: [
                        SizedBox(
                          width: 50,
                          height: 50,
                          child: IconButton(
                            tooltip: Strings.tooltipId,
                            onPressed: () {
                              Clipboard.setData(ClipboardData(text: event.id))
                                  .then((_) {
                                ref.read(copyButtonProvider.notifier).state =
                                    const Icon(
                                  Icons.done,
                                  color: Colors.lightGreen,
                                );
                                Future.delayed(const Duration(seconds: 3), () {
                                  ref.read(copyButtonProvider.notifier).state =
                                      const Icon(
                                    Icons.numbers,
                                    color: Colors.blueAccent,
                                  );
                                });
                              });
                            },
                            icon: copyIcon,
                          ),
                        ),
                        const SizedBox(
                          width: 8,
                        ),
                        SizedBox(
                          width: 50,
                          height: 50,
                          child: IconButton(
                            tooltip: Strings.tooltipExcel,
                            onPressed: event.excelLink == null
                                ? null
                                : () {
                                    if (event.excelLink != null) {
                                      launchUrl(Uri.parse(event.excelLink!));
                                    }
                                  },
                            icon: const Icon(
                              Icons.dataset_linked,
                              color: Colors.green,
                            ),
                          ),
                        ),
                        const SizedBox(
                          width: 8,
                        ),
                        SizedBox(
                          width: 50,
                          height: 50,
                          child: IconButton(
                            tooltip: Strings.tooltipDelete,
                            onPressed: () {
                              ref
                                  .read(eventProvider(widget.event.id).notifier)
                                  .deleteEvent(widget.event);
                              Navigator.of(context).pop();
                            },
                            icon: const Icon(
                              Icons.delete_forever,
                              color: Colors.red,
                            ),
                          ),
                        ),
                        const Spacer(),
                        TextButton(
                            onPressed: _isEdited
                                ? () {
                                    setState(() {
                                      eventDateTime = null;
                                      _guestsCountController.clear();
                                      _excelLinkController.clear();
                                      _locationController.clear();
                                      _dateController.clear();
                                      if (widget.event.expectedGuestsCount !=
                                          null) {
                                        _guestsCountController.text = widget
                                            .event.expectedGuestsCount
                                            .toString();
                                      }
                                      if (widget.event.date != null) {
                                        _dateController.text =
                                            DateFormat('dd.MM.yyyy – kk:mm')
                                                .format(widget.event.date!);
                                      }
                                      if (widget.event.location != null) {
                                        _locationController.text =
                                            widget.event.location!;
                                      }
                                      if (widget.event.excelLink != null) {
                                        _excelLinkController.text =
                                            widget.event.excelLink!;
                                      }
                                      _isEdited = false;
                                    });
                                  }
                                : null,
                            child: const Text(
                              Strings.cancel,
                              style: TextStyle(fontSize: 20),
                            )),
                        TextButton(
                            onPressed: _isEdited
                                ? () {
                                    setState(() {
                                      _errorMessage = null;
                                      _success = true;
                                      _isEdited = false;
                                    });
                                    ref
                                        .read(eventProvider(widget.event.id)
                                            .notifier)
                                        .updateEvent(widget.event.copyWith(
                                          excelLink:
                                              _excelLinkController.text.isEmpty
                                                  ? null
                                                  : _excelLinkController.text,
                                          date: eventDateTime,
                                          location:
                                              _locationController.text.isEmpty
                                                  ? null
                                                  : _locationController.text,
                                          expectedGuestsCount:
                                              _guestsCountController
                                                      .text.isEmpty
                                                  ? null
                                                  : int.parse(
                                                      _guestsCountController
                                                          .text),
                                        ))
                                        .then((_) {
                                      Future.delayed(Duration(seconds: 1), () {
                                        setState(() {
                                          _success = false;
                                        });
                                      });
                                    });
                                  }
                                : null,
                            child: _success
                                ? Icon(
                                    Icons.done,
                                    color: Colors.lightGreen,
                                  )
                                : const Text(
                                    Strings.save,
                                    style: TextStyle(fontSize: 20),
                                  )),
                      ],
                    ),
                  ],
                ),
              ),
            ),
          )),
    );
  }
}
