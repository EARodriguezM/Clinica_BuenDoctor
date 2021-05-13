import 'package:buen_doctor_app/constants.dart';
import 'package:buen_doctor_app/screens/sign_in/components/sign_in_form.dart';
import 'package:flutter/material.dart';
import '../../../size_config.dart';

class Body extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: SizedBox(
        width: double.infinity,
        child: Padding(
          padding:
              EdgeInsets.symmetric(horizontal: getProportionateScreenWidth(20)),
          child: SingleChildScrollView(
            child: Column(
              children: [
                SizedBox(height: SizeConfig.screenHeight * 0.04),
                Text(
                  "Bienvenido",
                  style: TextStyle(
                    color: kTextSecondaryColor,
                    fontSize: getProportionateScreenWidth(28),
                    fontWeight: FontWeight.bold,
                  ),
                ),
                SizedBox(height: SizeConfig.screenHeight * 0.03),
                Text(
                  'Ingrese con su correo institucional y \nsu contraseña para acceder a las funcionalidades',
                  textAlign: TextAlign.center,
                  style: TextStyle(
                    color: kTextTertiaryColor,
                    fontWeight: FontWeight.bold,
                  ),
                ),
                SizedBox(height: SizeConfig.screenHeight * 0.08),
                SignInForm(),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
