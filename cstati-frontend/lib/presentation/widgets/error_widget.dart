import 'package:event_flow/strings.dart';
import 'package:flutter/cupertino.dart';

class FutureErrorWidget extends StatelessWidget {
  const FutureErrorWidget({super.key});

  @override
  Widget build(BuildContext context) {
    return const Center(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Text(Strings.error),
        ],
      ),
    );
  }
}