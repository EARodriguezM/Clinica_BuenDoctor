import 'package:buen_doctor_app/components/default_button.dart';
import 'package:buen_doctor_app/constants.dart';
import 'package:buen_doctor_app/size_config.dart';
import 'package:flutter/material.dart';

class Body extends StatelessWidget {
  const Body({
    Key? key,
    required this.imagePath,
    required this.labelText,
  }) : super(key: key);

  final String imagePath;
  final String labelText;

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        SizedBox(height: SizeConfig.screenHeight * 0.04),
        Image.asset(
          imagePath,
          height: SizeConfig.screenHeight * 0.4,
        ),
        SizedBox(height: SizeConfig.screenHeight * 0.08),
        Text(
          labelText,
          style: TextStyle(
            fontSize: getProportionateScreenWidth(30),
            fontWeight: FontWeight.bold,
            color: kTextSecondaryColor,
          ),
        ),
        Spacer(
          flex: 2,
        ),
      ],
    );
  }
}
