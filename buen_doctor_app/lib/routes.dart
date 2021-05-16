import 'package:buen_doctor_app/screens/sign_in/sign_in_screen.dart';
import 'package:buen_doctor_app/screens/sign_in_state/sign_in_state_screen.dart';
import 'package:buen_doctor_app/screens/welcome/welcome_screen.dart';
import 'package:flutter/widgets.dart';

final Map<String, WidgetBuilder> routes = {
  WelcomeScreen.routeName: (context) => WelcomeScreen(),
  SignInScreen.routeName: (context) => SignInScreen(),
  SignInStateScreen.routeName: (context) => SignInStateScreen(),
};
