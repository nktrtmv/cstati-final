import 'package:event_flow/domain/model/event.dart';
import 'package:event_flow/domain/model/event_info.dart';
import 'package:event_flow/domain/model/enums/event_status.dart';
import 'package:event_flow/presentation/widgets/event_status_chip.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:intl/intl.dart';

class EventListWidget extends StatefulWidget {
  final _height = 360.0;
  final EventInfo event;

  const EventListWidget({super.key, required this.event});

  @override
  State<StatefulWidget> createState() => _EventListState();
}

class _EventListState extends State<EventListWidget> {
  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: widget._height,
      child: Card(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(8),
        ),
        clipBehavior: Clip.antiAlias,
        child: InkWell(
          borderRadius: BorderRadius.circular(8),
          onTap: () {
            context.push(
                Uri(path: '/event', queryParameters: {'id': widget.event.id})
                    .toString());
          },
          splashColor:
              Theme.of(context).colorScheme.onSurface.withOpacity(0.12),
          highlightColor: Colors.transparent,
          child: Padding(
            padding: const EdgeInsets.all(32),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.start,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  widget.event.name,
                  style: Theme.of(context).textTheme.displayMedium,
                ),
                const Spacer(),
                EventStatusChip(status: widget.event.status,),
              ],
            ),
          ),
        ),
      ),
    );
  }


}
