import 'package:buen_doctor_app/models/Appointment.dart';
import 'package:flutter/material.dart';

import 'Appointment.dart';
import 'UserType.dart';

class DataUser {
  late final String dataUserId;
  late final String firstName;
  late final String secondName;
  late final String firstSurname;
  late final String secondSurname;
  late final String password;
  late final String email;
  late final String mobile;
  late final Image profilePicture;
  late final bool status;
  late final String userTypeId;

  late final List<Appointment> appointments = [];
  late final UserType userType;
}
