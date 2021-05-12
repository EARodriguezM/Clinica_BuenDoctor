import 'package:buen_doctor_app/routes.dart';
import 'package:buen_doctor_app/theme.dart';
import 'package:flutter/material.dart';
import 'package:buen_doctor_app/screens/welcome/welcome_screen.dart';

main() {
  runApp(BuenDoctorApp());
}

class BuenDoctorApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Buen Doctor App',
      theme: theme(),
      //home: WelcomeScreen(),
      initialRoute: WelcomeScreen.routeName,
      routes: routes,
    );
  }
}
