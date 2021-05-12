import 'package:buen_doctor_app/models/DataUser.dart';
import 'package:flutter/material.dart';

import 'AppointmentStatus.dart';
import 'Patient.dart';

class Appointment {
  late final String appointmentId;
  late final String patientId;
  late final String dataUserId;
  late final String date;
  late final int appointmentStatusId;

  late final AppointmentStatus appointmentStatus;
  late final DataUser user;
  late final Patient patient;
}
