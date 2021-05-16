import 'package:buen_doctor_app/models/data_user.dart';
import 'package:flutter/material.dart';

import 'appointment_status.dart';
import 'patient.dart';

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
