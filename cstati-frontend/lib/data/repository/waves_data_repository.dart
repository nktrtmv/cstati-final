import 'package:event_flow/data/api/api_util/api_util_waves.dart';
import 'package:event_flow/domain/model/event_wave.dart';
import 'package:event_flow/domain/repository/waves_repository.dart';

class WavesDataRepository extends WavesRepository {
  final ApiUtilWaves _apiUtil;

  WavesDataRepository(this._apiUtil);

  @override
  Future<void> complete(String eventId, int waveOrdinal) async {
    await _apiUtil.complete(eventId, waveOrdinal);
  }

  @override
  Future<void> create(String eventId) async {
    await _apiUtil.create(eventId);
  }

  @override
  Future<void> delete(String eventId, int waveOrdinal) async {
    await _apiUtil.delete(eventId, waveOrdinal);
  }

  @override
  Future<List<EventWave>> getAll(String eventId) async {
    return _apiUtil.getAll(eventId);
  }

  @override
  Future<void> start(String eventId, int waveOrdinal) async {
    await _apiUtil.start(eventId, waveOrdinal);
  }

}