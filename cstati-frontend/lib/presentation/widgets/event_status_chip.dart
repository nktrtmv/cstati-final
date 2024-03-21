import 'package:event_flow/domain/model/enums/event_status.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';

class EventStatusChip extends StatelessWidget {
  final EventStatus status;
  const EventStatusChip({super.key, required this.status});

  @override
  Widget build(BuildContext context) {
    final Color clr = switch (status) {
      EventStatus.none => Colors.blueGrey,
      EventStatus.notStarted => Colors.blue[400]!,
      EventStatus.inProgress => Colors.yellow[400]!,
      EventStatus.finished => Colors.green[400]!,
    };
    return Chip(
      backgroundColor: clr,
      side: BorderSide.none,

      label: Text(
        Strings.getEventStatus(status),
        style: const TextStyle(color: Colors.black, fontSize: 24),
      ),
    );
  }
}

class EventStatusChipMovable {}