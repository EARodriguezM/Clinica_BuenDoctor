import 'package:buen_doctor_app/constants.dart';
import 'package:buen_doctor_app/screens/sign_in/components/body.dart';
import 'package:flutter/material.dart';

class SignInScreen extends StatelessWidget {
  static String routeName = '/sign_in';

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: kSecondaryColor,
      appBar: AppBar(
        title: Text('Iniciar Sesión'),
      ),
      body: Body(),
    );
  }
}
