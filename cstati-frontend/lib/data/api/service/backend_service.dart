import 'package:event_flow/data/api/contracts/cstati_accounts.dart';
import 'package:event_flow/data/api/contracts/cstati_collectors.dart';
import 'package:event_flow/data/api/contracts/cstati_events.dart';
import 'package:event_flow/data/api/contracts/cstati_finances.dart';
import 'package:event_flow/data/api/contracts/cstati_guests.dart';
import 'package:event_flow/data/api/contracts/cstati_tasks.dart';
import 'package:event_flow/data/api/contracts/cstati_tickets.dart';
import 'package:event_flow/data/api/contracts/cstati_waves.dart';

abstract class BackendService {

  final CstatiAccounts accounts;
  final CstatiEvents events;
  final CstatiFinances finances;
  final CstatiTasks tasks;
  final CstatiGuests guests;
  final CstatiPaymentCollectors collectors;
  final CstatiTickets tickets;
  final CstatiWaves waves;

  BackendService({
    required this.accounts,
    required this.events,
    required this.finances,
    required this.tasks,
    required this.guests,
    required this.collectors,
    required this.tickets,
    required this.waves,
  });
}
