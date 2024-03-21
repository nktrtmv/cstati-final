import 'package:event_flow/data/api/api_util/api_util_accounts.dart';
import 'package:event_flow/data/api/api_util/api_util_collectors.dart';
import 'package:event_flow/data/api/api_util/api_util_events.dart';
import 'package:event_flow/data/api/api_util/api_util_finances.dart';
import 'package:event_flow/data/api/api_util/api_util_guests.dart';
import 'package:event_flow/data/api/api_util/api_util_tasks.dart';
import 'package:event_flow/data/api/api_util/api_util_tickets.dart';
import 'package:event_flow/data/api/api_util/api_util_waves.dart';
import 'package:event_flow/data/api/service/prod_service.dart';
import 'package:event_flow/data/api/service/test_service.dart';

class ApiModule {
  static final _service = ProdService("http://localhost:5004");

  static ApiUtilAccounts? _apiUtilAccounts;
  static ApiUtilEvents? _apiUtilEvents;
  static ApiUtilFinances? _apiUtilFinances;
  static ApiUtilTasks? _apiUtilTasks;
  static ApiUtilGuests? _apiUtilGuests;
  static ApiUtilCollectors? _apiUtilCollectors;
  static ApiUtilTickets? _apiUtilTickets;
  static ApiUtilWaves? _apiUtilWaves;

  static ApiUtilAccounts apiUtilAccounts() {
    _apiUtilAccounts ??= ApiUtilAccounts(_service);
    return _apiUtilAccounts!;
  }

  static ApiUtilEvents apiUtilEvents() {
    _apiUtilEvents ??= ApiUtilEvents(_service);
    return _apiUtilEvents!;
  }

  static ApiUtilFinances apiUtilFinances() {
    _apiUtilFinances ??= ApiUtilFinances(_service);
    return _apiUtilFinances!;
  }

  static ApiUtilTasks apiUtilTasks() {
    _apiUtilTasks ??= ApiUtilTasks(_service);
    return _apiUtilTasks!;
  }

  static ApiUtilGuests apiUtilGuests() {
    _apiUtilGuests ??= ApiUtilGuests(_service);
    return _apiUtilGuests!;
  }

  static ApiUtilCollectors apiUtilCollectors() {
    _apiUtilCollectors ??= ApiUtilCollectors(_service);
    return _apiUtilCollectors!;
  }

  static ApiUtilTickets apiUtilTickets() {
    _apiUtilTickets ??= ApiUtilTickets(_service);
    return _apiUtilTickets!;
  }

  static ApiUtilWaves apiUtilWaves() {
    _apiUtilWaves ??= ApiUtilWaves(_service);
    return _apiUtilWaves!;
  }
}