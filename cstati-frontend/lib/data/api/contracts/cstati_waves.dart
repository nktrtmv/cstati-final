import 'package:event_flow/data/api/api_models/api_event_wave.dart';
import 'package:event_flow/data/api/contracts/concurrency_contract.dart';

abstract class CstatiWaves extends ConcurrencyContract {
  Future<void> create(String eventId);
  Future<void> delete(String eventId, int waveOrdinal);
  Future<void> start(String eventId, int waveOrdinal);
  Future<void> complete(String eventId, int waveOrdinal);
  Future<List<ApiEventWave>> getAll(String eventId);
}