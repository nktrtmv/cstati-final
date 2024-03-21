
import 'package:event_flow/data/api/service/backend_service.dart';
import 'package:event_flow/data/api/test_service/cstati_accounts.dart';
import 'package:event_flow/data/api/test_service/cstati_collectors.dart';
import 'package:event_flow/data/api/test_service/cstati_events.dart';
import 'package:event_flow/data/api/test_service/cstati_finances.dart';
import 'package:event_flow/data/api/test_service/cstati_guests.dart';
import 'package:event_flow/data/api/test_service/cstati_tasks.dart';
import 'package:event_flow/data/api/test_service/cstati_tickets.dart';
import 'package:event_flow/data/api/test_service/cstati_waves.dart';

class TestService extends BackendService {
  TestService() : super(
    accounts: CstatiAccountsTest(),
    events: CstatiEventsTest(),
    finances: CstatiFinancesTest(),
    tasks: CstatiTasksTest(),
    guests: CstatiGuestsTest(),
    collectors: CstatiPaymentCollectorsTest(),
    tickets: CstatiTicketsTest(),
    waves: CstatiWavesTest(),
  );
}
