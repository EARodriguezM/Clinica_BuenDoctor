import 'package:buen_doctor_app/constants.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:buen_doctor_app/Screens/Welcome/components/background.dart';
import 'package:buen_doctor_app/Screens/Login/login_screen.dart';
import 'package:buen_doctor_app/Components/rounded_button.dart';

class Body extends StatefulWidget {
  @override
  _BodyState createState() => _BodyState();
}

class _BodyState extends State<Body> {
  int _pageState = 0;

  double _loginYOffset = 0;

  @override
  Widget build(BuildContext context) {
    Size screenSize = MediaQuery.of(context).size;

    switch (_pageState) {
      case 0:
        _loginYOffset = screenSize.height;
        break;
      case 1:
        _loginYOffset = screenSize.height * 0.30;
        break;
      default:
    }

    return Stack(
      children: <Widget>[
        Background(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: <Widget>[
              Container(
                child: Column(
                  children: <Widget>[
                    Container(
                      margin: const EdgeInsets.only(top: 100),
                      child: Text(
                        "Clinica Buen Doctor",
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          color: textPrimaryColor,
                          fontSize: 28,
                        ),
                      ),
                    ),
                    Container(
                        margin: EdgeInsets.only(
                          top: 20,
                        ),
                        padding: EdgeInsets.symmetric(
                          horizontal: 30,
                        ),
                        child: Text(
                          "Bienvenido a la app donde podra gestionar el personal de atención y sus citas para con los pacientes.",
                          textAlign: TextAlign.center,
                          style: TextStyle(
                            color: textSecondaryColor,
                            fontSize: 16,
                            fontWeight: FontWeight.bold,
                          ),
                        ))
                  ],
                ),
              ),
              Container(
                padding: EdgeInsets.symmetric(horizontal: 32),
                child: SvgPicture.asset(
                  'assets/images/Hospital.svg',
                  width: screenSize.width,
                  alignment: Alignment.center,
                ),
              ),
              Container(),
              RoundedButton(
                text: Text(
                  "Ingresar",
                  style: TextStyle(
                    color: Colors.white,
                    fontSize: 16,
                    fontWeight: FontWeight.bold,
                  ),
                ),
                press: () {
                  setState(() {
                    if (_pageState != 0) {
                      _pageState = 0;
                    } else {
                      _pageState = 1;
                    }
                  });
                },
              ),
            ],
          ),
        ),
        Container(
          transform: Matrix4.translationValues(0, _loginYOffset, 1),
          child: Login(),
        ),
      ],
    );
  }
}
