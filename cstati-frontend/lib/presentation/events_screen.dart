import 'package:event_flow/domain/model/event.dart';
import 'package:event_flow/domain/state/events_screen_state.dart';
import 'package:event_flow/presentation/widgets/event_list_widget.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class EventsScreen extends ConsumerStatefulWidget {
  const EventsScreen({super.key});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() => _EventsScreenState();
}

class _EventsScreenState extends ConsumerState<EventsScreen> {
  @override
  Widget build(BuildContext context) {
    final eventsFuture = ref.watch(eventsProvider);
    return eventsFuture.when(data: (events) {
      return Center(
        child: Container(
          alignment: Alignment.topCenter,
          constraints: const BoxConstraints(
            maxWidth: 800,
          ),
          //padding: const EdgeInsets.symmetric(horizontal: 100),
          child: events.isEmpty
              ? Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Text(
                      "Мероприятий нет",
                      style: Theme.of(context).textTheme.displaySmall,
                    ),
                    const SizedBox(height: 16,),
                    Text(
                      "Создайте новое нажав на кнопку",
                      style: Theme.of(context).textTheme.displaySmall,
                    ),
                  ],
                )
              : ListView.builder(
                  itemCount: events.length,
                  itemBuilder: (context, index) {
                    return EventListWidget(
                      event: events.elementAt(index),
                    );
                  },
                ),
        ),
      );
    }, error: (obj, trace) {
      print(trace);
      return const Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Text(Strings.error),
          ],
        ),
      );
    }, loading: () {
      return const Center(
        child: CircularProgressIndicator(),
      );
    });
  }
}
