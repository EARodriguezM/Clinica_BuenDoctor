import 'package:buen_doctor_app/size_config.dart';
import 'package:flutter/material.dart';

// Background
const kPrimaryColor = Color(0xFFC1EADE);
const kPrimaryLightColor = Color(0xFFEBEFF3);
const kSecondaryColor = Color(0xFFFFFFFF);
const kTertiaryColor = Color(0xFF1E335E); //bottom navegation var

// Text
const kTextPrimaryColor = Color(0xFF3B60BF);
final kTextSecondaryColor = Color(0xFF282829).withOpacity(0.75);
const kTextTertiaryColor = Color(0xFF282829);

//Selected text
const kSelectedTextColor = Color(0xFFFC6D39);

// Item
const kItemPrimaryColor = Color(0xFFFFFFFF); //bottom navegation var
const kItemSecondaryColor = Color(0xFF49CFC1); //bottom navegation var

// Button
const kButtonPrimaryColor = Color(0xFF53DAF9);

// List
const kListPrimaryColor = Color(0xFF2B4986);
const kListSecondaryColor = Color(0xFF369EFF);
const kListTertiaryColor = Color(0xFF282829);

// Animation
const kAnimationDuration = Duration(milliseconds: 200);

const defaultDuration = Duration(milliseconds: 250);

// Heading
final headingStyle = TextStyle(
  fontSize: getProportionateScreenWidth(28),
  fontWeight: FontWeight.bold,
  color: Colors.black,
  height: 1.5,
);

// Form Error
// Login
final RegExp emailValidatorRegExp =
    RegExp(r"^[a-zA-Z0-9.]+@buendoctor.[a-zA-Z]+");
const String kEmailNullError =
    'Por favor, ingrese el E-Mail'; // Please, enter your email;
const String kInvalidEmailError =
    'Por favor, ingrese un E-Mail valido'; // Please, enter Valid Email;
const String kPassNullError =
    'Por favor, ingrese la contraseña'; // Please, enter password;
const String kShortPassError =
    'La contraseña es muy corta'; // Password is too short;
const String kMatchPassError =
    'Las contraseñas no coinciden'; // Passwords don't match;

// Register

// General
const String kIdNullError =
    'Por favor, ingrese la identificación'; // Please, enter id
const String kFirstNameNullError =
    'Por favor, ingrese el nombre'; // Please, enter name;
const String kFirstSurnameNullError =
    'Por favor, ingrese el primer apellido'; // Please, enter first surname;
const String kSecondSurnameNullError =
    'Por favor, ingrese el segundo apellido'; // Please, enter second surname;
const String kPhoneNumberNullError =
    'Por favor, ingrese el numero de telefono'; // Please, Enter phone number;

// Patient
const String kBirthayNullError =
    'Por favor, seleccione la fecha de nacimiento'; // Please, select birthday;
const String kMobileNumberNullError =
    'Por favor, ingrese el numero de celular'; // Please, Enter mobile number;
const String kAddressNullError =
    'Por favor, ingrese la dirección'; // Please, enter address;
const String kNeighborhoodNullError =
    'Por favor, ingrese el barrio'; // Please, enter neighborhood
const String kCityNullError =
    'Por favor, seleccione la ciudad'; // Please, select city;
