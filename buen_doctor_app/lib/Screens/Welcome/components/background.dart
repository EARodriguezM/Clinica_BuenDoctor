import 'package:buen_doctor_app/constants.dart';
import 'package:flutter/material.dart';

class Background extends StatelessWidget {
  final Widget child;
  const Background({
    Key? key,
    required this.child,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;

    return Container(
      height: size.height,
      width: double.infinity,
      child: Stack(
        children: <Widget>[
          AnimatedContainer(
            duration: Duration(
              milliseconds: 2000,
            ),
            color: backgroundSecondaryColor,
            child: child,
          ),
        ],
      ),
    );
  }
}
