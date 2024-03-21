
import 'package:event_flow/data/api/api_models/api_event_wave.dart';
import 'package:event_flow/data/api/contracts/cstati_waves.dart';
import 'package:event_flow/data/api/prod_service/prod_mixin.dart';

class CstatiWavesProd extends CstatiWaves with ProdMixin{

  final String url;
  CstatiWavesProd(this.url);

  @override
  Future<void> create(String eventId) async {
    print("$eventId - $concurrencyToken");
    await post("$url/Create", {
      "eventId": eventId,
      "concurrencyToken": concurrencyToken,
    });
  }

  @override
  Future<void> delete(String eventId, int waveOrdinal) async {
    await post("$url/Delete", {
      "eventId": eventId,
      "ordinal": waveOrdinal,
      "concurrencyToken": concurrencyToken,
    });
  }

  @override
  Future<void> complete(String eventId, int waveOrdinal) async {
    await post("$url/Complete", {
      "eventId": eventId,
      "ordinal": waveOrdinal,
      "concurrencyToken": concurrencyToken,
    });
  }

  @override
  Future<List<ApiEventWave>> getAll(String eventId) async {
    final json = await post("$url/GetAll", {
      "eventId": eventId,
    });
    concurrencyToken = json['concurrencyToken'];
    return List<ApiEventWave>.from(json['waves'].map((wave) => ApiEventWave.fromApi(wave)));
  }

  @override
  Future<void> start(String eventId, int waveOrdinal) async {
    await post("$url/Start", {
      "eventId": eventId,
      "ordinal": waveOrdinal,
      "concurrencyToken": concurrencyToken,
    });
  }

}