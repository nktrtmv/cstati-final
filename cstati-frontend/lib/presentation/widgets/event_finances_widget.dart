import 'package:event_flow/domain/model/account_info.dart';
import 'package:event_flow/domain/model/enums/payment_bank.dart';
import 'package:event_flow/domain/model/event_finance.dart';
import 'package:event_flow/domain/model/payment_collector.dart';
import 'package:event_flow/domain/state/accounts_state.dart';
import 'package:event_flow/domain/state/event_collectors_state.dart';
import 'package:event_flow/domain/state/event_finances_state.dart';
import 'package:event_flow/presentation/dialogs/create_collector_dialog.dart';
import 'package:event_flow/presentation/dialogs/create_expense_dialog.dart';
import 'package:event_flow/presentation/widgets/collctor_card_widget.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:pie_chart/pie_chart.dart';

class EventFinances extends ConsumerStatefulWidget {
  final String eventId;

  const EventFinances({super.key, required this.eventId});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() => _EventFinancesState();
}

class _EventFinancesState extends ConsumerState<EventFinances> {
  @override
  Widget build(BuildContext context) {
    double screenWidth = MediaQuery.of(context).size.width;
    int columnCount =
        (screenWidth / 600).floor() > 2 ? 2 : (screenWidth / 600).floor();
    final eventFinanceFuture = ref.watch(eventFinanceProvider(widget.eventId));
    return eventFinanceFuture.when(
      data: (eventFinance) {
        return ScrollConfiguration(
          behavior: ScrollConfiguration.of(context).copyWith(scrollbars: false),
          child: SingleChildScrollView(
            primary: false,
            child: Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.stretch,
                children: [
                  _getFinancesInfo(eventFinance, context),
                  Row(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Expanded(child: _getExpensesInfo(eventFinance, context)),
                      Expanded(child: _getCollectorsInfo(context)),
                    ],
                  )
                  // GridView.count(
                  //   crossAxisCount: columnCount,
                  //   shrinkWrap: true,
                  //   children: [
                  //     _getExpensesInfo(eventFinance, context),
                  //     _getCollectorsInfo(context),
                  //   ],
                  // ),
                ],
              ),
            ),
          ),
        );
      },
      error: (obj, trace) {
        print("$obj - $trace");
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

  Widget _getFinancesInfo(EventFinance finance, BuildContext context) {
    return Container(
      constraints: const BoxConstraints(
        maxHeight: 400,
      ),
      child: Card(
        child: Padding(
          padding: const EdgeInsets.all(32.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                "${Strings.collected}: ${finance.collected.toString()}",
                style: Theme.of(context).textTheme.displayMedium,
              ),
              Text(
                "${Strings.balance}: ${finance.balance.toString()}",
                style: Theme.of(context).textTheme.displayMedium,
              ),
              Text(
                "${Strings.revenue}: ${finance.revenue.toString()}",
                style: Theme.of(context).textTheme.displayMedium,
              ),
              const Spacer(),
              Row(
                mainAxisAlignment: MainAxisAlignment.end,
                children: [
                  ElevatedButton(onPressed: () {
                    ref.read(eventFinanceProvider(widget.eventId).notifier).actualizeRevenue();
                  }, child: const Text(Strings.actualizeRevenue))
                ],
              )
            ],
          ),
        ),
      ),
    );
  }

  Widget _getExpensesInfo(EventFinance finance, BuildContext context) {
    final totalExpense =
        finance.expenses.fold(0.0, (value, element) => value + element.amount);
    final dataMap = <String, double>{};
    dataMap
        .addEntries(finance.expenses.map((e) => MapEntry(e.market, e.amount)));
    return Card(
      child: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Container(
          height: 800,
          child: Column(
            children: [
              Text(
                "${Strings.expenses}: ${totalExpense.toStringAsFixed(2)}₽",
                style: Theme.of(context).textTheme.displaySmall,
              ),
              const SizedBox(
                height: 16,
              ),
              // ConstrainedBox(
              //   constraints: const BoxConstraints(
              //     maxWidth: 300,
              //   ),
              //   child: PieChart(
              //     dataMap: dataMap,
              //   ),
              // ),
              // const SizedBox(
              //   height: 16,
              // ),
              IconButton(
                onPressed: () {
                  _createExpenseDialog(context);
                },
                tooltip: Strings.tooltipAddExpense,
                icon: const Icon(Icons.add),
              ),
              const SizedBox(
                height: 16,
              ),
              if (finance.expenses.isEmpty) Text(Strings.noExpenses, style: Theme.of(context).textTheme.displayMedium,),
              if (finance.expenses.isNotEmpty) Expanded(
                child: Card(
                  color: Theme.of(context).colorScheme.background,
                  surfaceTintColor: Colors.transparent,
                  shadowColor: null,
                  child: ScrollConfiguration(
                    behavior: ScrollConfiguration.of(context).copyWith(overscroll: false),
                    child: ListView.separated(
                      itemCount: finance.expenses.length,
                      shrinkWrap: true,
                      itemBuilder: (context, index) {
                        final expense = finance.expenses.elementAt(index);
                        return ExpansionTile(
                          title: Text(
                              "${expense.amount.toStringAsFixed(2)}₽ ${expense.market}"),
                          subtitle: Text(expense.person.fullName),
                          trailing: IconButton(
                            onPressed: () {
                              ref
                                  .read(
                                      eventFinanceProvider(widget.eventId).notifier)
                                  .delete(expense);
                            },
                            icon: const Icon(
                              Icons.delete,
                              color: Colors.red,
                            ),
                          ),
                          children: [
                            Text(expense.description),
                          ],
                        );
                      },
                      separatorBuilder: (context, index) => const Divider(),
                    ),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget _getCollectorsInfo(BuildContext context) {
    final collectorsFuture = ref.watch(eventCollectorsProvider(widget.eventId));
    return collectorsFuture.when(
      data: (collectors) {
        return Card(
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Container(
              height: 800,
              child: SingleChildScrollView(
                child: Column(
                  children: [
                    Text(
                      Strings.collectors,
                      style: Theme.of(context).textTheme.displaySmall,
                    ),
                    const SizedBox(
                      height: 16,
                    ),
                    IconButton(
                      onPressed: () {
                        _createEditCollectorDialog(context);
                      },
                      tooltip: Strings.tooltipAddCollector,
                      icon: const Icon(Icons.add),
                    ),
                    const SizedBox(
                      height: 16,
                    ),
                    if (collectors.isEmpty) Text(Strings.noCollectors, style: Theme.of(context).textTheme.displayMedium,),
                    // Wrap(
                    //   children: collectors.map((e) => CollectorCard(collector: e)).toList(),
                    // ),
                    ...collectors.map(
                      (col) => SizedBox(
                        height: 80,
                        child: ListTile(
                          title: Row(
                            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                            children: [
                              Text(col.person.fullName),
                              Text(col.phone),
                              Text(col.cardNumber),
                              Text(
                                Strings.getPaymentBank(col.bank),
                              ),
                            ],
                          ),
                          trailing: IconButton(
                            onPressed: () {
                              ref
                                  .read(eventCollectorsProvider(widget.eventId)
                                      .notifier)
                                  .delete(col.person.login);
                            },
                            icon: const Icon(
                              Icons.delete,
                              color: Colors.red,
                            ),
                          ),
                          onTap: () {
                            _createEditCollectorDialog(context, col);
                          },
                        ),
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ),
        );
      },
      error: (obj, trace) {
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
      },
      loading: () {
        return const Center(
          child: CircularProgressIndicator(),
        );
      },
    );
  }

  Future<void> _createEditCollectorDialog(BuildContext context,
      [PaymentCollector? collector]) async {
    AccountInfo? selectedInfo;
    return showDialog(
      context: context,
      builder: (context) =>
          CreateEditCollectorDialog(eventId: widget.eventId, collector: collector),
    );
  }

  Future<void> _createExpenseDialog(BuildContext context) async {
    return showDialog(
      context: context,
      builder: (context) => CreateExpenseDialog(eventId: widget.eventId),
    );
  }
}