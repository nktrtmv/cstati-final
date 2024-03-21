import 'package:event_flow/domain/model/enums/user_access.dart';
import 'package:event_flow/domain/state/accounts_state.dart';
import 'package:event_flow/presentation/widgets/error_widget.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class EventAccesses extends ConsumerStatefulWidget {
  final String eventId;

  const EventAccesses({super.key, required this.eventId});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() => _EventAccessesState();
}

class _EventAccessesState extends ConsumerState<EventAccesses> {
  @override
  Widget build(BuildContext context) {
    final accountsFuture = ref.watch(accountsProvider);
    return accountsFuture.when(
      data: (accounts) {
        return Padding(
          padding: const EdgeInsets.all(16.0),
          child: Card(
            child: Padding(
              padding: const EdgeInsets.all(8.0),
              child: ListView.builder(
                itemCount: accounts.length,
                itemBuilder: (context, index) {
                  final account = accounts.elementAt(index);
                  return ListTile(
                    title: Text(account.fullName),
                    trailing: Wrap(
                      spacing: 8.0,
                      children: AccountAccess.values
                          .map(
                            (access) => FilterChip(
                              label: Text(Strings.getUserAccess(access)),
                              selected: account.accesses.contains(access),
                              onSelected: (value) {
                                if (value) {
                                  ref.read(accountsProvider.notifier).addAccountAccess(account, access);
                                } else {
                                  ref.read(accountsProvider.notifier).deleteAccountAccess(account, access);
                                }
                              },
                            ),
                          )
                          .toList(),
                    ),
                  );
                },
              ),
            ),
          ),
        );
      },
      error: (obj, trace) => const FutureErrorWidget(),
      loading: () {
        return const Center(
          child: CircularProgressIndicator(),
        );
      },
    );
  }
}
