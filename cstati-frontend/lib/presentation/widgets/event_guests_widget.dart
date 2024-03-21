import 'package:event_flow/domain/model/enums/educational_program.dart';
import 'package:event_flow/domain/model/enums/guest_gender.dart';
import 'package:event_flow/domain/model/enums/payment_status.dart';
import 'package:event_flow/domain/model/enums/ticket_type.dart';
import 'package:event_flow/domain/model/enums/wave_status.dart';
import 'package:event_flow/domain/model/event_guest.dart';
import 'package:event_flow/domain/model/event_guest_payment_info.dart';
import 'package:event_flow/domain/model/exceptions/backend_exception.dart';
import 'package:event_flow/domain/state/event_tickets_state.dart';
import 'package:event_flow/domain/state/event_waves_state.dart';
import 'package:event_flow/domain/state/guests_widget_state.dart';
import 'package:event_flow/presentation/dialogs/create_edit_guest_dialog.dart';
import 'package:event_flow/presentation/dialogs/send_deadline_message_dialog.dart';
import 'package:event_flow/presentation/dialogs/send_message_dialog.dart';
import 'package:event_flow/strings.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';

class EventGuests extends ConsumerStatefulWidget {
  final String eventId;

  const EventGuests({super.key, required this.eventId});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() => _EventsGuestsState();
}

class _EventsGuestsState extends ConsumerState<EventGuests> {
  int? _selectedWave;

  @override
  Widget build(BuildContext context) {
    final wavesFuture = ref.watch(eventWavesProvider(widget.eventId));
    return wavesFuture.when(
      data: (waves) {
        return Padding(
          padding: const EdgeInsets.all(16.0),
          child: Card(
            child: Padding(
              padding: const EdgeInsets.only(
                  left: 8.0, right: 8.0, top: 16.0, bottom: 8.0),
              child: SingleChildScrollView(
                child: Column(
                  children: [
                    Row(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        DropdownMenu(
                          initialSelection: null,
                          dropdownMenuEntries: [const DropdownMenuEntry(value: null, label: Strings.allWaves), ...waves
                              .map((e) => DropdownMenuEntry(
                                  value: e.ordinal,
                                  label: "${Strings.wave} ${e.ordinal}"))
                              .toList()],
                          onSelected: (index) {
                            setState(() {
                              _selectedWave = index;
                            });
                          },
                        ),
                      ],
                    ),
                    const SizedBox(
                      height: 32,
                    ),
                    Builder(builder: (context) {
                      // if (_selectedWave == null) {
                      //   return Text(
                      //     Strings.selectWave,
                      //     style: Theme.of(context).textTheme.displayMedium,
                      //   );
                      // }
                      final guestsFuture = ref.watch(eventGuestsProvider(
                          UniqueWave(widget.eventId, _selectedWave)));
                      return guestsFuture.when(
                        data: (guests) {
                          return GuestsTable(
                            guests: guests,
                            uniqueWave:
                                UniqueWave(widget.eventId, _selectedWave),
                          );
                        },
                        error: (obj, trace) {
                          print(obj);
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
                    }),
                  ],
                ),
              ),
            ),
          ),
        );
      },
      error: (obj, trace) {
        print(obj);
        return const Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              Text(Strings.error),
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
}

class GuestsDataSource extends DataTableSource {
  final BuildContext context;
  final WidgetRef ref;
  final UniqueWave uniqueWave;
  late List<EventGuest> sortedData;

  GuestsDataSource(this.context, this.ref, this.uniqueWave);

  void setData(List<EventGuest> rawData, int sortColumn, bool sortAscending) {
    sortedData = rawData.toList()
      ..sort((EventGuest a, EventGuest b) {
        if (sortColumn == 0) {
          return a.id.compareTo(b.id) * (sortAscending ? 1 : -1);
        } else if (sortColumn == 1) {
          return a.fullName.compareTo(b.fullName) * (sortAscending ? 1 : -1);
        } else if (sortColumn == 3) {
          return a.telegram.compareTo(b.telegram) * (sortAscending ? 1 : -1);
        } else if (sortColumn == 4) {
          return a.paymentInfo.status.name
                  .compareTo(b.paymentInfo.status.name) *
              (sortAscending ? 1 : -1);
        } else if (sortColumn == 5) {
          return a.program.name.compareTo(b.program.name) *
              (sortAscending ? 1 : -1);
        } else if (sortColumn == 6) {
          return a.phone.compareTo(b.phone) * (sortAscending ? 1 : -1);
        }
        return 0;
      });
    notifyListeners();
  }

  @override
  int get rowCount => sortedData.length;

  @override
  DataRow? getRow(int index) {
    return DataRow(
        onSelectChanged: (selected) {
          if (selected != null && selected) {
            showDialog(
              context: context,
              builder: (context) => CreateEditGuestDialog(uWave: uniqueWave, guest: sortedData.elementAt(index),),
            );
          }
        },
        cells: [
          DataCell(Text(sortedData.elementAt(index).id)),
          DataCell(Text(sortedData.elementAt(index).fullName)),
          DataCell(
              Text(Strings.getGuestGender(sortedData.elementAt(index).gender))),
          DataCell(Text(sortedData.elementAt(index).telegram)),
          DataCell(Text(Strings.getPaymentStatus(
              sortedData.elementAt(index).paymentInfo.status))),
          DataCell(Text(
              Strings.getProgramName(sortedData.elementAt(index).program))),
          DataCell(Text(sortedData.elementAt(index).phone)),
          DataCell(Text(sortedData.elementAt(index).isLegalAge
              ? Strings.yes
              : Strings.no)),
          DataCell(Text(
              Strings.getEventTicketType(sortedData.elementAt(index).ticket))),
          DataCell(Text(sortedData.elementAt(index).needsTransfer
              ? Strings.yes
              : Strings.no)),
        ]);
  }

  @override
  bool get isRowCountApproximate => false;

  @override
  int get selectedRowCount => 0;
}

class MyCustomScrollBehavior extends MaterialScrollBehavior {
  // Override behavior methods and getters like dragDevices
  @override
  Set<PointerDeviceKind> get dragDevices => {
    PointerDeviceKind.touch,
    PointerDeviceKind.mouse,
  };
}


class GuestsTable extends ConsumerStatefulWidget {
  final List<EventGuest> guests;
  final UniqueWave uniqueWave;

  const GuestsTable(
      {super.key, required this.guests, required this.uniqueWave});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() => _GuestsTableState();
}

class _GuestsTableState extends ConsumerState<GuestsTable> {
  late final GuestsDataSource dataSource;
  int _columnIndex = 0;
  bool _columnAscending = true;
  bool _allowCreation = false;

  void _sort(int columnIndex, bool ascending) {
    setState(() {
      _columnIndex = columnIndex;
      _columnAscending = ascending;
      dataSource.setData(widget.guests, _columnIndex, _columnAscending);
    });
  }

  @override
  void initState() {
    super.initState();
    dataSource = GuestsDataSource(context, ref, widget.uniqueWave)
      ..setData(widget.guests, 0, true);
    ref.read(eventWavesProvider(widget.uniqueWave.eventId)).whenData((value) {
      setState(() {
        _allowCreation = value.where((wave) => wave.ordinal == widget.uniqueWave.waveOrdinal).any((wave) => wave.status == EventWaveStatus.inProgress);
        if (widget.uniqueWave.waveOrdinal == null) {
          _allowCreation = true;
        }
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    ref.listen(eventGuestsProvider(widget.uniqueWave), (previous, next) {
      next.whenData((value) {
        dataSource.setData(value, _columnIndex, _columnAscending);
      });
    });
    ref.listen(eventWavesProvider(widget.uniqueWave.eventId), (previous, next) {
      next.whenData((value) {
        setState(() {
          _allowCreation = value.where((wave) => wave.ordinal == widget.uniqueWave.waveOrdinal).any((wave) => wave.status == EventWaveStatus.inProgress);
          if (widget.uniqueWave.waveOrdinal == null) {
            _allowCreation = true;
          }
        });
      });
    });
    return SizedBox(
      width: MediaQuery.of(context).size.width,
      child: ScrollConfiguration(
        behavior: MyCustomScrollBehavior(),
        child: PaginatedDataTable(
          actions: [
            IconButton(
              onPressed: () {
                showDialog(
                    context: context,
                    builder: (context) =>
                        SendDeadlineMessageDialog(eventId: widget.uniqueWave.eventId));
              },
              icon: const Icon(Icons.schedule_send),
              tooltip: Strings.tooltipSendMessageDeadline,
            ),
            IconButton(
              onPressed: () {
                showDialog(
                    context: context,
                    builder: (context) =>
                        SendMessageDialog(eventId: widget.uniqueWave.eventId));
              },
              icon: const Icon(Icons.send),
              tooltip: Strings.tooltipSendMessage,
            ),
            IconButton(
              onPressed: _allowCreation ? () {
                showDialog(
                  context: context,
                  builder: (context) => CreateEditGuestDialog(uWave: widget.uniqueWave),
                );
              } : null,
              icon: const Icon(Icons.add),
              tooltip: Strings.tooltipAddGuest,
            ),
            IconButton(
              onPressed: _allowCreation ? () async {
                var result = await FilePicker.platform.pickFiles(
                    type: FileType.custom,
                    allowedExtensions: ['csv'],
                    withReadStream: true);
                if (result != null) {
                  ref
                      .read(eventGuestsProvider(widget.uniqueWave).notifier)
                      .addBatch(result.files.single);
                }
              } : null,
              icon: const Icon(Icons.file_upload),
              tooltip: Strings.tooltipAddBatch,
            ),
          ],
          header: const Text(Strings.eventInfoGuests),
          horizontalMargin: 8.0,
          showCheckboxColumn: false,
          columnSpacing: 16.0,
          sortColumnIndex: _columnIndex,
          sortAscending: _columnAscending,
          dragStartBehavior: DragStartBehavior.start,
          rowsPerPage: 10,
          columns: [
            DataColumn(
              label: const Text(Strings.tableColId),
              onSort: _sort,
            ),
            DataColumn(
              label: const Text(Strings.tableColName),
              onSort: _sort,
            ),
            const DataColumn(
              label: Text(Strings.tableColGender),
            ),
            DataColumn(
              label: const Text(Strings.tableColTelegram),
              onSort: _sort,
            ),
            DataColumn(
              label: const Text(Strings.tableColPayment),
              onSort: _sort,
            ),
            DataColumn(
              label: const Text(Strings.tableColProgram),
              onSort: _sort,
            ),
            DataColumn(
              label: const Text(Strings.tableColPhone),
              onSort: _sort,
            ),
            const DataColumn(
              label: Text(Strings.tableColIsLegalAge),
            ),
            const DataColumn(
              label: Text(Strings.tableColTicket),
            ),
            const DataColumn(
              label: Text(Strings.tableColNeedsTransfer),
            ),
          ],
          source: dataSource,
        ),
      ),
    );
  }
}