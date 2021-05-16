import 'package:buen_doctor_app/components/progress_hud.dart';
import 'package:buen_doctor_app/constants.dart';
import 'package:buen_doctor_app/providers/InAsyncCall.dart';
import 'package:buen_doctor_app/screens/sign_in/components/body.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:flutter/foundation.dart';

class SignInScreen extends StatelessWidget {
  static String routeName = '/sign_in';

  const SignInScreen({Key? key}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return ProgressHUD(
      child: Scaffold(
        backgroundColor: kSecondaryColor,
        appBar: AppBar(
          title: Text('Iniciar Sesión'),
        ),
        body: Body(),
      ),
      inAsyncCall: context.watch<InAsyncCall>().inAsyncCall,
    );
  }
}
