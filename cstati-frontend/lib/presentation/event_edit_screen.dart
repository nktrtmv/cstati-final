import 'dart:math';

import 'package:event_flow/domain/model/event.dart';
import 'package:event_flow/domain/model/enums/event_status.dart';
import 'package:event_flow/domain/state/event_screen_state.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:intl/intl.dart';

class EventEditScreen extends ConsumerStatefulWidget {
  final Event event;

  const EventEditScreen({super.key, required this.event});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() =>
      _EventEditScreenState();
}

class _EventEditScreenState extends ConsumerState<EventEditScreen> {
  final _editFormKey = GlobalKey<FormState>();
  DateTime selectedDate = DateTime.now();
  TimeOfDay selectedTime = TimeOfDay.now();
  EventStatus selectedStatus = EventStatus.none;
  final _guestsCountController = TextEditingController();
  final _excelLinkController = TextEditingController();
  final _locationController = TextEditingController();

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
        context: context,
        locale: const Locale("ru", "RU"),
        initialDate: selectedDate,
        firstDate: DateTime(2020),
        lastDate: DateTime(2101));
    if (picked != null && picked != selectedDate) {
      setState(() {
        selectedDate = picked;
      });
    }
  }

  Future<void> _selectTime(BuildContext context) async {
    final TimeOfDay? picked = await showTimePicker(
      context: context,
      initialTime: selectedTime,
      builder: (BuildContext context, Widget? child) {
        return MediaQuery(
          data: MediaQuery.of(context).copyWith(alwaysUse24HourFormat: true),
          child: child!,
        );
      },
    );
    if (picked != null && picked != selectedTime) {
      setState(() {
        selectedTime = picked;
      });
    }
  }

  @override
  void initState() {
    super.initState();
    _guestsCountController.text = widget.event.expectedGuestsCount?.toString() ?? '';
    _excelLinkController.text = widget.event.excelLink ?? '';
    _locationController.text = widget.event.location ?? '';
    selectedStatus = widget.event.status;
  }

  @override
  void dispose() {
    _guestsCountController.dispose();
    _excelLinkController.dispose();
    _locationController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text(Strings.tooltipEdit),
      ),
      body: Center(
        child: Container(
          constraints: const BoxConstraints(
            maxWidth: 800,
          ),
          child: Card(
            child: Padding(
              padding: const EdgeInsets.all(16.0),
              child: Form(
                key: _editFormKey,
                child: Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.only(
                          top: 16.0, left: 8, right: 8, bottom: 8),
                      child: TextFormField(
                        controller: _guestsCountController,
                        validator: (value) {
                          if (value == null) {
                            return Strings.errorTextField;
                          }
                          if (value.isNotEmpty && int.tryParse(value) == null) {
                            return Strings.errorTextFieldDouble;
                          }
                          if (value.isNotEmpty && int.parse(value) < 0) {
                            return Strings.errorTextFieldDouble;
                          }
                          return null;
                        },
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(),
                          labelText: Strings.guestsCount,
                        ),
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: TextFormField(
                        controller: _locationController,
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(),
                          labelText: Strings.eventEditLocation,
                        ),
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: TextFormField(
                        controller: _excelLinkController,
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(),
                          labelText: Strings.eventEditLink,
                        ),
                      ),
                    ),
                    Row(
                      mainAxisSize: MainAxisSize.min,
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: [
                        Expanded(
                          child: Padding(
                            padding: const EdgeInsets.all(8.0),
                            child: ElevatedButton(
                              onPressed: () {
                                _selectDate(context);
                              },
                              child: const Text(Strings.eventSelectDate),
                            ),
                          ),
                        ),
                        Expanded(
                          child: Padding(
                            padding: const EdgeInsets.all(8.0),
                            child: ElevatedButton(
                              onPressed: () {
                                _selectTime(context);
                              },
                              child: const Text(Strings.eventSelectTime),
                            ),
                          ),
                        ),
                      ],
                    ),
                    Row(
                      mainAxisSize: MainAxisSize.min,
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: [
                        Expanded(
                          child: Center(
                              child: Text(DateFormat('dd.MM.yyyy')
                                  .format(selectedDate))),
                        ),
                        Expanded(
                          child: Center(
                              child: Text(
                                  "${selectedTime.hour}:${selectedTime.minute}")),
                        ),
                      ],
                    ),
                    const SizedBox(
                      height: 16,
                    ),
                    Wrap(
                      children: [
                        ChoiceChip(
                          label: Text(
                              Strings.getEventStatus(EventStatus.notStarted)),
                          selected: selectedStatus == EventStatus.notStarted,
                          onSelected: (value) {
                            setState(() {
                              if (value) {
                                selectedStatus = EventStatus.notStarted;
                              }
                            });
                          },
                        ),
                        const SizedBox(width: 8),
                        ChoiceChip(
                          label: Text(
                              Strings.getEventStatus(EventStatus.inProgress)),
                          selected: selectedStatus == EventStatus.inProgress,
                          onSelected: (value) {
                            setState(() {
                              if (value) {
                                selectedStatus = EventStatus.inProgress;
                              }
                            });
                          },
                        ),
                        const SizedBox(width: 8),
                        ChoiceChip(
                          label: Text(
                              Strings.getEventStatus(EventStatus.finished)),
                          selected: selectedStatus == EventStatus.finished,
                          onSelected: (value) {
                            setState(() {
                              if (value) {
                                selectedStatus = EventStatus.finished;
                              }
                            });
                          },
                        ),
                      ],
                    ),
                    const SizedBox(
                      height: 16,
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.end,
                      children: [
                        ElevatedButton(
                            onPressed: () {
                              Navigator.pop(context);
                            },
                            child: const Text(Strings.cancel)),
                        const SizedBox(width: 8),
                        ElevatedButton(
                            onPressed: () {
                              if (_editFormKey.currentState!.validate()) {
                                ref
                                    .read(
                                        eventProvider(widget.event.id).notifier)
                                    .updateEvent(
                                      Event(
                                        id: widget.event.id,
                                        name: widget.event.name,
                                        excelLink: _excelLinkController.text.isEmpty ? null : _excelLinkController.text,
                                        status: selectedStatus,
                                        date: DateTime(
                                            selectedDate.year,
                                            selectedDate.month,
                                            selectedDate.day,
                                            selectedTime.hour,
                                            selectedTime.minute),
                                        location: _locationController.text.isEmpty ? null : _locationController.text,
                                        expectedGuestsCount: int.tryParse(_guestsCountController.text),
                                      ),
                                    );
                                Navigator.pop(context);
                              }
                            },
                            child: const Text(Strings.save)),
                      ],
                    )
                  ],
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }
}
