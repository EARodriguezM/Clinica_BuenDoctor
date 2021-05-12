import 'package:buen_doctor_app/components/default_button.dart';
import 'package:buen_doctor_app/screens/sign_in/sign_in_screen.dart';
import 'package:buen_doctor_app/size_config.dart';

import '../../../constants.dart';
import 'welcome_content.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:buen_doctor_app/components/rounded_button.dart';

class Body extends StatefulWidget {
  @override
  _BodyState createState() => _BodyState();
}
//Bienvenido a la app donde podra gestionar el personal de atención y sus citas para con los pacientes.

class _BodyState extends State<Body> {
  int _currentPage = 0;
  List<Map<String, String>> _welcomeData = [
    {
      'text':
          'Bienvenido a Buen Doctor App. \nDonde se desea lo mejor para el paciente.',
      'image': 'assets/images/welcome_1.png'
    },
    {
      'text':
          'Aqui usted podra administrar a sus pacientes \ny sus datos personales.',
      "image": "assets/images/welcome_2.png"
    },
    {
      'text':
          'Tambien podra agendar y gestionar las citas de \naquellos pacientes que lo requieran.',
      "image": "assets/images/welcome_3.png"
    },
  ];
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: SizedBox(
        width: double.infinity,
        child: Column(
          children: <Widget>[
            Expanded(
              flex: 3,
              child: PageView.builder(
                onPageChanged: (value) {
                  setState(() {
                    _currentPage = value;
                  });
                },
                itemCount: _welcomeData.length,
                itemBuilder: (context, index) => WelcomeContent(
                  text: _welcomeData[index]['text'],
                  image: _welcomeData[index]['image'],
                ),
              ),
            ),
            Expanded(
              flex: 2,
              child: Padding(
                padding: EdgeInsets.symmetric(
                    horizontal: getProportionateScreenWidth(20)),
                child: Column(
                  children: <Widget>[
                    Spacer(),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: List.generate(
                        _welcomeData.length,
                        (index) => buildDot(index: index),
                      ),
                    ),
                    Spacer(flex: 2),
                    DefaultButton(
                      text: "Continuar",
                      press: () {
                        Navigator.pushNamed(context, SignInScreen.routeName);
                      },
                    ),
                    Spacer(),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }

  AnimatedContainer buildDot({required int index}) {
    return AnimatedContainer(
      duration: kAnimationDuration,
      margin: EdgeInsets.only(right: 5),
      height: 6,
      width: _currentPage == index ? 20 : 6,
      decoration: BoxDecoration(
        color: _currentPage == index ? kItemPrimaryColor : kItemSecondaryColor,
        borderRadius: BorderRadius.circular(3),
      ),
    );
  }
}
