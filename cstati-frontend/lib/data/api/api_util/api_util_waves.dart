import 'package:event_flow/data/api/api_util/api_util.dart';
import 'package:event_flow/data/api/service/backend_service.dart';
import 'package:event_flow/data/mapper/event_wave_mapper.dart';
import 'package:event_flow/domain/model/event_wave.dart';

class ApiUtilWaves extends ApiUtil{

  ApiUtilWaves(super.backendService);

  Future<void> create(String eventId) async {
    await backendService.waves.create(eventId);
  }
  Future<void> delete(String eventId, int waveOrdinal) async {
    await backendService.waves.delete(eventId, waveOrdinal);
  }
  Future<void> start(String eventId, int waveOrdinal) async {
    await backendService.waves.start(eventId, waveOrdinal);
  }
  Future<void> complete(String eventId, int waveOrdinal) async {
    await backendService.waves.complete(eventId, waveOrdinal);
  }
  Future<List<EventWave>> getAll(String eventId) async {
    final waves = await backendService.waves.getAll(eventId);
    return List<EventWave>.from(waves.map((wave) => EventWaveMapper.fromApi(wave)));
  }
}