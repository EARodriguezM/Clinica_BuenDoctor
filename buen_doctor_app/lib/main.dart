import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';
import 'package:buen_doctor_app/constants.dart';
import 'package:buen_doctor_app/Screens/Welcome/welcome_screen.dart';

main() {
  runApp(BuenDoctorApp());
}

class BuenDoctorApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        primaryColor: backgroundPrimaryColor,
        fontFamily: "Lato",
      ),
      home: WelcomeScreen(),
    );
  }
}
