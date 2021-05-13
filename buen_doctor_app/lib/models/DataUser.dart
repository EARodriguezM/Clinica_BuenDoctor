import 'package:buen_doctor_app/models/Appointment.dart';
import 'package:flutter/material.dart';

import 'Appointment.dart';
import 'UserType.dart';

class DataUser {
  late final String dataUserId;
  late final String firstName;
  late final String? secondName;
  late final String firstSurname;
  late final String secondSurname;
  late final String password;
  late final String email;
  late final String mobile;
  late final Image? profilePicture;
  late final bool status;
  late final int userTypeId;

  late final List<Appointment>? appointments = [];
  late final UserType userType;

  DataUser(
      {required this.dataUserId,
      required this.firstName,
      required this.secondName,
      required this.firstSurname,
      required this.secondSurname,
      required this.email,
      required this.mobile,
      required this.profilePicture});

  DataUser.authenticateRequest({required this.email, required this.password});

  Map<String, dynamic> authenticateRequestToJson() {
    Map<String, dynamic> request = {
      'email': email.trim(),
      'password': password.trim(),
    };

    return request;
  }

  DataUser.authenticateResponse(
      {required this.dataUserId,
      required this.firstName,
      this.secondName,
      required this.firstSurname,
      required this.secondSurname,
      required this.email,
      required this.mobile,
      this.profilePicture,
      required token});

  factory DataUser.authenticateResponseFromJSon(Map<String, dynamic> response) {
    return DataUser.authenticateResponse(
        dataUserId: response['dataUserId'] != null ? response['dataUserId'] : '',
        firstName: response['firstName'] != null ? response['firstName'] : '',
        secondName: response['secondName'] != null ? response['secondName'] : '',
        firstSurname: response['firstSurname'] != null ? response['firstSurname'] : '',
        secondSurname: response['secondSurname'] != null ? response['secondSurname'] : '',
        email: response['email'] != null ? response['email'] : '',
        mobile: response['mobile'] != null ? response['mobile'] : '',
        profilePicture: response['profilePicture'] != null ? response['profilePicture'] : '',
        token: response['token'] != null ? response['token'] : '');
  }

  DataUser.registerRequest(
      {required this.dataUserId,
      required this.firstName,
      this.secondName,
      required this.firstSurname,
      required this.secondSurname,
      required this.password,
      required this.email,
      required this.mobile,
      required this.userTypeId,
      this.profilePicture});

  Map<String, dynamic> registerRequestToJson() {
    Map<String, dynamic> request = {
      'dataUserId': dataUserId.trim(),
      'firstName': firstName.trim(),
      'secondName': secondName!.trim(),
      'firstSurname': firstSurname.trim(),
      'secondSurname': secondSurname.trim(),
      'password': password.trim(),
      'email': email.trim(),
      'mobile': mobile.trim(),
      'userTypeId': userTypeId,
      'profilePicture': profilePicture,
    };

    return request;
  }
}
