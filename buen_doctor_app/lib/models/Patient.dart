import 'package:flutter/material.dart';

import 'Appointment.dart';

class Patient {
  late final String patientId;
  late final String firstName;
  late final String secondName;
  late final String firstSurname;
  late final String secondSurname;
  late final Image profilePicture;
  late final DateTime birthday;
  late final String email;
  late final String phone;
  late final String mobile;
  late final String direction;
  late final String neighborhood;
  late final String city;
  late final bool status;

  late final List<Appointment> appointments;
}
