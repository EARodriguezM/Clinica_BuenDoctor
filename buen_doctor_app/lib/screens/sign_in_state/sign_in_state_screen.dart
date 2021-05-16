import 'package:buen_doctor_app/screens/sign_in_state/components/body.dart';
import 'package:flutter/material.dart';

class SignInStateScreen extends StatelessWidget {
  static String routeName = "/sign_in_state";
  final bool isOk;

  const SignInStateScreen({
    Key? key,
    this.isOk = false,
  }) : super(key: key);
  @override
  Widget build(BuildContext context) {
    String imagePath = '';
    String labelText = '';

    if (isOk) {
      imagePath = 'assets/images/success.png';
      labelText = 'Acceso Permitido';
    } else {
      imagePath = 'assets/images/fail.png';
      labelText = 'Acceso Denegado';
    }

    return Scaffold(
      appBar: AppBar(
        leading: SizedBox(),
        centerTitle: true,
        title: Text("Verificado"),
      ),
      body: Body(
        imagePath: imagePath,
        labelText: labelText,
      ),
    );
  }
}
