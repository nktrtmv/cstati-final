import 'package:event_flow/domain/model/event_wave.dart';

abstract class WavesRepository {
  Future<void> create(String eventId);
  Future<void> delete(String eventId, int waveOrdinal);
  Future<void> start(String eventId, int waveOrdinal);
  Future<void> complete(String eventId, int waveOrdinal);
  Future<List<EventWave>> getAll(String eventId);
}