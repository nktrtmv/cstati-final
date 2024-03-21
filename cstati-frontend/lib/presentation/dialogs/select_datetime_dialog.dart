import 'package:flutter/material.dart';

Future<DateTime?> selectDateTime(BuildContext context, DateTime initial) async {
  final DateTime? pickedDate = await showDatePicker(
      context: context,
      locale: const Locale("ru", "RU"),
      initialDate: initial,
      firstDate: DateTime(2020),
      lastDate: DateTime(2101));
  if (pickedDate == null) {
    return null;
  }
  final TimeOfDay? pickedTime = await showTimePicker(
    context: context,
    initialTime: TimeOfDay.fromDateTime(initial),
    builder: (BuildContext context, Widget? child) {
      return MediaQuery(
        data: MediaQuery.of(context).copyWith(alwaysUse24HourFormat: true),
        child: child!,
      );
    },
  );
  if (pickedDate != null && pickedTime != null) {
    return DateTime(pickedDate.year, pickedDate.month, pickedDate.day, pickedTime.hour, pickedTime.minute);
  }
  return null;
}