import 'package:buen_doctor_app/status_code.dart';

import 'api_ip.dart';
import 'package:buen_doctor_app/models/data_user.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;

String controllerURL = ApiIp.serverIP + '/DataUser';

class DataUserService {
  Future<DataUser> authentication(DataUser authenticationRequest) async {
    var url = Uri.parse(controllerURL + '/authenticate');

    final authenticationResponse = await http.post(url, body: authenticationRequest.authenticateRequestToJson());
    var status = StatusCode(authenticationResponse.statusCode);

    if (status.statusCode == 200) {
      return DataUser.authenticateResponseFromJSon(json.decode(authenticationResponse.body));
    } else {
      throw Exception(status.statusDescription);
    }
  }

  Future<String> register(DataUser registerRequest) async {
    var url = Uri.parse(controllerURL + '/authentication');

    final registerResponse = await http.post(url, body: registerRequest.registerRequestToJson());
    var status = StatusCode(registerResponse.statusCode);

    if (status.statusCode == 200) {
      return 'Registered';
    } else {
      throw Exception(status.statusDescription);
    }
  }
}
