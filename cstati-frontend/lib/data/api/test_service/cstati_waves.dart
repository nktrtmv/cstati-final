
import 'package:event_flow/data/api/api_models/api_event_wave.dart';
import 'package:event_flow/data/api/contracts/cstati_waves.dart';
import 'package:event_flow/domain/model/enums/wave_status.dart';

class CstatiWavesTest extends CstatiWaves {
  @override
  Future<void> create(String eventId) async {
    print('CstatiWavesTest::create');
  }

  @override
  Future<void> delete(String eventId, int waveOrdinal) async {
    print('CstatiWavesTest::delete');
  }

  @override
  Future<void> complete(String eventId, int waveOrdinal) async {
    print('CstatiWavesTest::complete');
  }

  @override
  Future<List<ApiEventWave>> getAll(String eventId) async {
    print('CstatiWavesTest::getAll');
    return [ApiEventWave(ordinal: 1, status: EventWaveStatus.notStarted)];
  }

  @override
  Future<void> start(String eventId, int waveOrdinal) async {
    print('CstatiWavesTest::start');
  }

}