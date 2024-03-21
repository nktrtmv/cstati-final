import 'package:event_flow/data/api/prod_service/cstati_accounts.dart';
import 'package:event_flow/data/api/prod_service/cstati_collectors.dart';
import 'package:event_flow/data/api/prod_service/cstati_events.dart';
import 'package:event_flow/data/api/prod_service/cstati_finances.dart';
import 'package:event_flow/data/api/prod_service/cstati_guests.dart';
import 'package:event_flow/data/api/prod_service/cstati_tasks.dart';
import 'package:event_flow/data/api/prod_service/cstati_tickets.dart';
import 'package:event_flow/data/api/prod_service/cstati_waves.dart';
import 'package:event_flow/data/api/service/backend_service.dart';

class ProdService extends BackendService {
  ProdService(String url) : super(
    accounts: CstatiAccountsProd('$url/accounts'),
    events: CstatiEventsProd('$url/events'),
    finances: CstatiFinancesProd('$url/events/finances'),
    tasks: CstatiTasksProd('$url/events/tasks'),
    guests: CstatiGuestsProd('$url/events/workflows/guests'),
    collectors: CstatiPaymentCollectorsProd('$url/events/workflows/payments-collectors'),
    tickets: CstatiTicketsProd('$url/events/workflows/tickets'),
    waves: CstatiWavesProd('$url/events/workflows/waves'),
  );
}
