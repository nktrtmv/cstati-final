import 'package:event_flow/domain/model/enums/ticket_type.dart';
import 'package:event_flow/domain/model/enums/wave_status.dart';
import 'package:event_flow/domain/model/exceptions/backend_exception.dart';
import 'package:event_flow/domain/state/event_tasks_state.dart';
import 'package:event_flow/domain/state/event_tickets_state.dart';
import 'package:event_flow/domain/state/event_waves_state.dart';
import 'package:event_flow/presentation/widgets/event_tickets_widget.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:intl/intl.dart';

class EventWaves extends ConsumerStatefulWidget {
  final String eventId;

  const EventWaves({super.key, required this.eventId});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() => _EventWavesState();
}

class _EventWavesState extends ConsumerState<EventWaves> {
  @override
  Widget build(BuildContext context) {
    final wavesFuture = ref.watch(eventWavesProvider(widget.eventId));
    return wavesFuture.when(
      data: (waves) {
        return Scaffold(
          appBar: null,
          body: Padding(
            padding: const EdgeInsets.all(16.0),
            child: waves.isEmpty
                ? Center(
                    child: Text(
                      Strings.noWaves,
                      style: Theme.of(context).textTheme.displayMedium,
                    ),
                  )
                : ListView.builder(
                    itemCount: waves.length,
                    itemBuilder: (context, index) {
                      final wave = waves.elementAt(index);
                      return Card(
                        child: Padding(
                          padding: const EdgeInsets.all(16.0),
                          child: ExpansionTile(
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(8),
                            ),
                            title: Column(
                              mainAxisSize: MainAxisSize.min,
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Text(
                                  "${Strings.wave} #${wave.ordinal}",
                                  style:
                                      Theme.of(context).textTheme.displaySmall,
                                ),
                                const SizedBox(
                                  height: 16,
                                ),
                                if (wave.start != null)
                                  Text(
                                    "${Strings.startWave}: ${DateFormat('dd-MM-yyyy kk:mm').format(wave.start!)}",
                                    style: Theme.of(context)
                                        .textTheme
                                        .displaySmall,
                                  ),
                                if (wave.end != null)
                                  Text(
                                    "${Strings.endWave}: ${DateFormat('dd-MM-yyyy kk:mm').format(wave.end!)}",
                                    style: Theme.of(context)
                                        .textTheme
                                        .displaySmall,
                                  ),
                                const SizedBox(
                                  height: 16,
                                ),
                                _getWaveStatusBadge(wave.status),
                              ],
                            ),
                            children: [
                              Text(
                                Strings.tickets,
                                style: Theme.of(context).textTheme.displaySmall,
                              ),
                              const SizedBox(
                                height: 8,
                              ),
                              EventTicketsWidget(
                                  eventId: widget.eventId,
                                  waveOrdinal: wave.ordinal,
                                  status: wave.status),
                              const SizedBox(
                                height: 8,
                              ),
                              if (wave.status == EventWaveStatus.notStarted)
                                ElevatedButton.icon(
                                  label: const Text(Strings.waveStart),
                                  onPressed: () {
                                    ref
                                        .read(eventWavesProvider(widget.eventId)
                                            .notifier)
                                        .start(wave.ordinal);
                                  },
                                  icon: const Icon(
                                    Icons.play_arrow,
                                    color: Colors.green,
                                  ),
                                ),
                              if (wave.status == EventWaveStatus.inProgress)
                                ElevatedButton.icon(
                                  label: const Text(Strings.waveEnd),
                                  onPressed: () {
                                    ref
                                        .read(eventWavesProvider(widget.eventId)
                                            .notifier)
                                        .complete(wave.ordinal);
                                  },
                                  icon: const Icon(
                                    Icons.stop,
                                    color: Colors.red,
                                  ),
                                ),
                              const SizedBox(height: 8,),
                              if (wave.status == EventWaveStatus.notStarted) ElevatedButton.icon(
                                label: const Text(Strings.waveDelete),
                                onPressed: () {
                                  ref
                                      .read(eventWavesProvider(widget.eventId)
                                      .notifier)
                                      .delete(wave.ordinal);
                                },
                                icon: const Icon(
                                  Icons.delete,
                                  color: Colors.red,
                                ),
                              ),
                            ],
                          ),
                        ),
                      );
                    },
                  ),
          ),
          floatingActionButton: FloatingActionButton(
            onPressed: () {
              ref.read(eventWavesProvider(widget.eventId).notifier).add();
            },
            child: const Icon(Icons.add),
          ),
        );
      },
      error: (obj, trace) {
        return Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              const Text(Strings.error),
              if (obj is BackendException) Text(obj.value['detail']),
            ],
          ),
        );
      },
      loading: () {
        return const Center(
          child: CircularProgressIndicator(),
        );
      },
    );
  }

  Widget _getWaveStatusBadge(EventWaveStatus status) {
    final Color clr = switch (status) {
      EventWaveStatus.none => Colors.blueGrey,
      EventWaveStatus.notStarted => Colors.blue,
      EventWaveStatus.inProgress => Colors.yellow,
      EventWaveStatus.finished => Colors.green,
    };
    return Chip(
      backgroundColor: clr,
      side: BorderSide.none,
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(15)),
      label: Text(
        Strings.getEventWaveStatus(status),
        style: TextStyle(color: Colors.black),
      ),
    );
  }
}
