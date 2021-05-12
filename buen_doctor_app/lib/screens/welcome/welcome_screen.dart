import 'package:buen_doctor_app/size_config.dart';
import 'package:flutter/material.dart';
import 'package:buen_doctor_app/screens/welcome/components/body.dart';

class WelcomeScreen extends StatelessWidget {
  static String routeName = '/welcome';
  @override
  Widget build(BuildContext context) {
    // initialize the class in the starting screen
    SizeConfig().init(context);
    return Scaffold(
      body: Body(),
    );
  }
}
