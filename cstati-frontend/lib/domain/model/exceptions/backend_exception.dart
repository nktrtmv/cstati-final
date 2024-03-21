import 'package:flutter_riverpod/flutter_riverpod.dart';

class BackendException implements Exception {
  Map<String, dynamic> value;
  BackendException(this.value);

  @override
  String toString() {
    return value["detail"];
  }
}


final exceptionProvider = StateProvider<BackendException?>((ref) => null);