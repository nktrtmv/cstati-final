import 'package:event_flow/domain/model/exceptions/backend_exception.dart';
import 'package:event_flow/domain/state/auth_state.dart';
import 'package:event_flow/presentation/dialogs/create_event_dialog.dart';
import 'package:event_flow/presentation/events_screen.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';


class MainScreen extends ConsumerStatefulWidget {
  const MainScreen({super.key});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() => _MainScreenState();
}

class _MainScreenState extends ConsumerState<MainScreen> {
  int _selectedIndex = 0;
  final List<Widget> _widgets = [
    const EventsScreen(),
  ];
  final List<String> _titles = [
    Strings.events,
  ];

  @override
  Widget build(BuildContext context) {
    ref.listen(exceptionProvider, (prev, next) {
      if (next != null) {
        showDialog(context: context, builder: (context) =>
            AlertDialog(
              title: const Text(Strings.error),
              content: Text(next.value['detail'] ?? next.value.toString()),
              actions: [
                TextButton(onPressed: () {
                  ref.read(exceptionProvider.notifier).state = null;
                  Navigator.of(context).pop();
                }, child: const Text(Strings.cancel)),
              ],
            )
        );
      }
    });
    final drawerHeader = DrawerHeader(
      child: Image.asset('assets/icons/logo_cstati.png'),
    );
    final drawerItems = Column(
      children: [
        drawerHeader,
        ListTile(
          title: const Text(Strings.events),
          leading: const Icon(Icons.event),
          onTap: () {
            setState(() {
              _selectedIndex = 0;
            });
            Navigator.pop(context);
          },
        ),
        Expanded(child: Container()),
        ListTile(
          title: IconButton(
            onPressed: () {
              ref.read(authProvider.notifier).signOut();
            },
            icon: const Icon(Icons.logout),
          ),
        ),
      ],
    );
    return Scaffold(
      appBar: AppBar(
        title: Text(_titles.elementAt(_selectedIndex)),
      ),
      body: SelectionArea(child: _widgets.elementAt(_selectedIndex),),
      drawer: Drawer(
        child: drawerItems,
      ),
      floatingActionButton: _selectedIndex == 0
          ? FloatingActionButton(
              tooltip: Strings.createEvent,
              onPressed: () {
                showDialog(context: context, builder: (context) => const CreateEventDialog());
              },
              child: const Icon(Icons.add),
            )
          : null,
    );
  }
}
