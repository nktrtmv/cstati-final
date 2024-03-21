import 'package:event_flow/domain/model/enums/event_status.dart';
import 'package:event_flow/domain/model/exceptions/backend_exception.dart';
import 'package:event_flow/domain/state/event_screen_state.dart';
import 'package:event_flow/presentation/widgets/event_accesses_widget.dart';
import 'package:event_flow/presentation/widgets/event_finances_widget.dart';
import 'package:event_flow/presentation/widgets/event_general_widget.dart';
import 'package:event_flow/presentation/widgets/event_guests_widget.dart';
import 'package:event_flow/presentation/widgets/event_tasks_widget.dart';
import 'package:event_flow/presentation/widgets/event_waves_widget.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class EventScreen extends ConsumerStatefulWidget {
  final String eventId;
  const EventScreen({super.key, required this.eventId});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() => _EventScreenState();
}

class _EventScreenState extends ConsumerState<EventScreen> with SingleTickerProviderStateMixin{
  late TabController _tabController;

  @override
  void initState() {
    _tabController = TabController(length: 5, vsync: this);
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    var futureEvent = ref.watch(eventProvider(widget.eventId));
    return Scaffold(
      appBar: AppBar(),
      body: SelectionArea(
        child: futureEvent.when(
          data: (event) {
            return Scaffold(
              appBar: TabBar(
                controller: _tabController,
                onTap: (index) {
                  if (event.status == EventStatus.notStarted) {
                    setState(() {
                      if (index == 0 || index == 2 || index == 4) {
                        _tabController.index = index;
                      } else {
                        _tabController.index = _tabController.previousIndex;
                      }
                    });
                  }
                },
                tabs: const [
                  Tab(
                    child: Text(Strings.eventInfoGeneral, style: TextStyle(fontSize: 20),),
                  ),
                  Tab(
                    child: Text(Strings.eventInfoWaves, style: TextStyle(fontSize: 20),),
                  ),
                  Tab(
                    child: Text(Strings.eventInfoTasks, style: TextStyle(fontSize: 20),),
                  ),
                  Tab(
                    child: Text(Strings.eventInfoGuests, style: TextStyle(fontSize: 20),),
                  ),
                  Tab(
                    child: Text(Strings.eventInfoFinances, style: TextStyle(fontSize: 20),),
                  ),
                ],
              ),
              body: TabBarView(
                controller: _tabController,
                children: [
                  EventGeneral(event: event),
                  EventWaves(eventId: widget.eventId),
                  EventTasks(eventId: widget.eventId),
                  EventGuests(eventId: widget.eventId),
                  EventFinances(eventId: widget.eventId),
                ],
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
        ),
      ),
    );
  }
}
