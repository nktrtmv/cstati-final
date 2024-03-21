import 'package:event_flow/data/api/service/backend_service.dart';

abstract class ApiUtil {
  final BackendService backendService;
  ApiUtil(this.backendService);
}