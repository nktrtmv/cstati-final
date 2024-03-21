import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';

class NoEventScreen extends StatelessWidget {
  const NoEventScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      body: Center(
        child: Text(Strings.noEvent, style: Theme.of(context).textTheme.displayMedium,),
      ),
    );
  }
}