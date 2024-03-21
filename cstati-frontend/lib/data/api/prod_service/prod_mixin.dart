import 'dart:convert';

import 'package:event_flow/domain/model/exceptions/backend_exception.dart';
import 'package:file_picker/file_picker.dart';
import 'package:http/http.dart' as http;

mixin ProdMixin {
  Future<Map<String, dynamic>> post(String url, Map<String, dynamic> params, [Map<String, dynamic>? queryParams]) async {
    final response = await http.post(
      Uri.parse(url),
      body: jsonEncode(params),
      headers: <String, String>{
        'accept': 'text/plain',
        'Content-Type': 'application/json',
      },
    );
    if (response.statusCode != 200) {
      throw BackendException(jsonDecode(response.body));
    }
    return jsonDecode(response.body);
  }

  Future<void> multipart(String url, Map<String, dynamic> params, PlatformFile file) async {
    final request = http.MultipartRequest("POST", Uri.parse(url));
    params.forEach((key, value) {
      request.fields[key] = value;
    });
    request.files.add(http.MultipartFile("csvFile", file.readStream!, file.size, filename: file.name));
    final response = await request.send();
    if (response.statusCode != 200) {
      throw Exception("Status code: ${response.statusCode}");
    }
  }
}