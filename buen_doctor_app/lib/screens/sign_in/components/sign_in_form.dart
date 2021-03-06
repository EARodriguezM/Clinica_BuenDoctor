import 'package:buen_doctor_app/components/default_button.dart';
import 'package:buen_doctor_app/components/form_errors.dart';
import 'package:buen_doctor_app/components/surfix_icon.dart';
import 'package:buen_doctor_app/constants.dart';
import 'package:buen_doctor_app/helpers/keyboard.dart';
import 'package:buen_doctor_app/models/data_user.dart';
import 'package:buen_doctor_app/providers/InAsyncCall.dart';
import 'package:buen_doctor_app/screens/sign_in_state/sign_in_state_screen.dart';
import 'package:buen_doctor_app/services/data_user_service.dart';
import 'package:buen_doctor_app/size_config.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class SignInForm extends StatefulWidget {
  @override
  _SignInFormState createState() => _SignInFormState();
}

class _SignInFormState extends State<SignInForm> {
  final _formKey = GlobalKey<FormState>();
  late String email;
  late String password;
  bool remember = false;

  final List<String> errors = [];

  void addError({required String error}) {
    if (!errors.contains(error))
      setState(() {
        errors.add(error);
      });
  }

  void removeError({required String error}) {
    if (errors.contains(error))
      setState(() {
        errors.remove(error);
      });
  }

  @override
  Widget build(BuildContext context) {
    return Form(
      key: _formKey,
      child: Column(
        children: [
          buildEmailFormField(),
          SizedBox(
            height: getProportionateScreenHeight(30),
          ),
          buildPasswordFormField(),
          SizedBox(height: getProportionateScreenHeight(30)),
          Row(
            children: [
              Checkbox(
                value: remember,
                activeColor: kPrimaryColor,
                onChanged: (value) {
                  setState(() {
                    remember = value!;
                  });
                },
              ),
              Text("Recuerdame"),
              Spacer(),
              GestureDetector(
                //onTap: () => Navigator.pushNamed(
                //context, ForgotPasswordScreen.routeName),
                child: Text(
                  "Ha olvidado su contrase??a?",
                  style: TextStyle(decoration: TextDecoration.underline),
                ),
              )
            ],
          ),
          SizedBox(height: getProportionateScreenHeight(10)),
          FormErrors(errors: errors),
          SizedBox(height: getProportionateScreenHeight(20)),
          DefaultButton(
            text: "Ingresar",
            press: () {
              if (_formKey.currentState!.validate()) {
                _formKey.currentState!.save();
                KeyboardUtil.hideKeyboard(context);
                signIn(context);
              }
            },
          ),
        ],
      ),
    );
  }

  signIn(BuildContext context) async {
    context.read<InAsyncCall>().initAsyncCall();
    DataUser authenticationRequest = new DataUser.authenticateRequest(email: email, password: password);
    DataUserService dataUserService = new DataUserService();

    try {
      await dataUserService.authentication(authenticationRequest).then((authenticationResponse) => {
            context.read<InAsyncCall>().finalizeAsynCall(),
            if (authenticationResponse.runtimeType == DataUser)
              {
                if (authenticationResponse.token.isNotEmpty)
                  {Navigator.pushNamed(context, SignInStateScreen.routeName)}
                else
                  {Navigator.pushNamed(context, SignInStateScreen.routeName)}
              }
          });
    } catch (e) {
      context.read<InAsyncCall>().finalizeAsynCall();
      print(e);
    }
  }

  buildEmailFormField() {
    return TextFormField(
      keyboardType: TextInputType.emailAddress,
      onSaved: (newValue) => email = newValue!.toLowerCase(),
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: kEmailNullError);
        }
        // if (emailValidatorRegExp.hasMatch(value + '@buendoctor.com')) {
        //   removeError(error: kInvalidEmailError);
        // } else
        if (emailValidatorRegExp.hasMatch(value)) {
          removeError(error: kInvalidEmailError);
        }

        return null;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: kEmailNullError);
          return "";
        } else if (!emailValidatorRegExp.hasMatch(value)
            //&& !emailValidatorRegExp.hasMatch(value + '@buendoctor.com')
            ) {
          addError(error: kInvalidEmailError);
          return "";
        }
        return null;
      },
      decoration: InputDecoration(
        labelText: 'E-Mail',
        hintText: 'Ingrese su E-Mail',
        floatingLabelBehavior: FloatingLabelBehavior.always,
        suffixIcon: SurffixIcon(svgIcon: "assets/icons/Mail.svg"),
      ),
    );
  }

  buildPasswordFormField() {
    return TextFormField(
      obscureText: true,
      onSaved: (newValue) => password = newValue!,
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: kPassNullError);
        } else if (value.length >= 8) {
          removeError(error: kShortPassError);
        }
        return null;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: kPassNullError);
          return "";
        } else if (value.length < 8) {
          addError(error: kShortPassError);
          return "";
        }
        return null;
      },
      decoration: InputDecoration(
        labelText: "Contrase??a",
        hintText: "Ingrese su contrase??a",
        floatingLabelBehavior: FloatingLabelBehavior.always,
        suffixIcon: SurffixIcon(svgIcon: "assets/icons/Lock.svg"),
      ),
    );
  }
}
