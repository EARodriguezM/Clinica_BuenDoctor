import 'package:buen_doctor_app/constants.dart';
import 'package:buen_doctor_app/size_config.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

class WelcomeContent extends StatelessWidget {
  const WelcomeContent({
    Key? key,
    this.text,
    this.image,
  }) : super(key: key);
  final String? text, image;

  @override
  Widget build(BuildContext context) {
    return Column(
      children: <Widget>[
        Spacer(flex: 2),
        Text(
          'Buen Doctor App',
          style: TextStyle(
            fontSize: getProportionateScreenWidth(36),
            color: kTextPrimaryColor,
            fontWeight: FontWeight.bold,
          ),
        ),
        Spacer(),
        Text(
          text!,
          textAlign: TextAlign.center,
          style: TextStyle(
            fontWeight: FontWeight.bold,
          ),
        ),
        Spacer(flex: 2),
        Image.asset(
          image!,
          width: getProportionateScreenWidth(325),
        )
      ],
    );
  }
}
