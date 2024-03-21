import 'package:event_flow/domain/state/accounts_state.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class AccountSearchWidget extends ConsumerStatefulWidget {
  final Function(String? login) onSelect;
  final String? errorText;
  const AccountSearchWidget({super.key, required this.onSelect, this.errorText});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() => _AccountSearchWidgetState();

}

class _AccountSearchWidgetState extends ConsumerState<AccountSearchWidget> {
  final _searchController = TextEditingController();
  String? _selectedLogin;

  @override
  void dispose() {
    _searchController.dispose();
    super.dispose();
  }

  @override
  void initState() {
    super.initState();
    ref.read(accountsProvider.notifier).getWithQuery(_searchController.text);
    _searchController.addListener(() {
      ref.read(accountsProvider.notifier).getWithQuery(_searchController.text);
    });
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        TextField(
          controller: _searchController,
          decoration: InputDecoration(
            border: const OutlineInputBorder(),
            labelText: Strings.selectUser,
            errorText: widget.errorText,
          ),
        ),
        const SizedBox(
          height: 16,
        ),
        Builder(
          builder: (context) {
            final accountsFuture = ref.watch(accountsProvider);
            return accountsFuture.when(
              data: (accounts) {
                return Wrap(
                  spacing: 8.0,
                  runSpacing: 8.0,
                  children: accounts
                      .map(
                        (account) => ChoiceChip(
                      label: Text(account.fullName),
                      selected: _selectedLogin == account.login,
                      onSelected: (value) {
                        if (value) {
                          widget.onSelect(account.login);
                          setState(() {
                            _selectedLogin = account.login;
                          });
                        }
                      },
                    ),
                  )
                      .toList(),
                );
              },
              error: (e, t) {
                return Text(e.toString());
              },
              loading: () => const CircularProgressIndicator(),
            );
          },
        ),
      ],
    );
  }

}