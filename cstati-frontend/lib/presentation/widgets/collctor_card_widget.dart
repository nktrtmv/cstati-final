import 'dart:math';

import 'package:event_flow/domain/model/payment_collector.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class CollectorCard extends ConsumerStatefulWidget {
  final PaymentCollector collector;
  const CollectorCard({super.key, required this.collector});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() => _CollectorCardState();
}

class _CollectorCardState extends ConsumerState<CollectorCard> {
  @override
  Widget build(BuildContext context) {
    return InkWell(
      child: Card(
        color: Colors.deepPurple,
        child: Padding(
          padding: EdgeInsets.only(top: 16),
          child: SizedBox(
            width: 300,
            height: 300,
            child: Column(
              children: [
                Text(widget.collector.person.fullName),
                Text(widget.collector.person.login),
                Text(widget.collector.cardNumber),
                Text(widget.collector.bank.name),
                Spacer(),
                Row(
                  children: [
                    Expanded(child: IconButton(onPressed: () {}, icon: Icon(Icons.edit))),
                    Expanded(child: IconButton(onPressed: () {}, icon: Icon(Icons.delete))),
                  ],
                )
              ],
            ),
          ),
        ),
      ),
    );
  }
}