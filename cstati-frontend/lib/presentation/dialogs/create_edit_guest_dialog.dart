import 'package:event_flow/domain/model/enums/educational_program.dart';
import 'package:event_flow/domain/model/enums/guest_gender.dart';
import 'package:event_flow/domain/model/enums/payment_status.dart';
import 'package:event_flow/domain/model/enums/ticket_type.dart';
import 'package:event_flow/domain/model/event_guest.dart';
import 'package:event_flow/domain/model/event_guest_payment_info.dart';
import 'package:event_flow/domain/state/event_tickets_state.dart';
import 'package:event_flow/domain/state/guests_widget_state.dart';
import 'package:event_flow/strings.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class CreateEditGuestDialog extends ConsumerStatefulWidget {
  final UniqueWave uWave;
  final EventGuest? guest;

  const CreateEditGuestDialog({super.key, required this.uWave, this.guest});

  @override
  ConsumerState<ConsumerStatefulWidget> createState() =>
      _CreateEditGuestDialogState();
}

class _CreateEditGuestDialogState extends ConsumerState<CreateEditGuestDialog> {
  final _formKey = GlobalKey<FormState>();
  late final TextEditingController _fullNameController;
  late final TextEditingController _telegramController;
  late final TextEditingController _phoneController;
  GuestGender gender = GuestGender.none;
  PaymentStatus paymentStatus = PaymentStatus.none;
  EducationalProgram program = EducationalProgram.none;
  late ValueNotifier<bool> isLegalAge;
  late ValueNotifier<bool> needsTransfer;
  TicketType ticket = TicketType.none;

  @override
  void initState() {
    super.initState();
    _fullNameController =
        TextEditingController(text: widget.guest?.fullName ?? '');
    _telegramController =
        TextEditingController(text: widget.guest?.telegram ?? '');
    _phoneController = TextEditingController(text: widget.guest?.phone ?? '');
    gender = widget.guest?.gender ?? GuestGender.none;
    paymentStatus = widget.guest?.paymentInfo.status ?? PaymentStatus.none;
    program = widget.guest?.program ?? EducationalProgram.none;
    isLegalAge = ValueNotifier<bool>(widget.guest?.isLegalAge ?? false);
    needsTransfer = ValueNotifier<bool>(widget.guest?.needsTransfer ?? false);
    ticket = widget.guest?.ticket ?? TicketType.none;
  }

  @override
  void dispose() {
    _fullNameController.dispose();
    _telegramController.dispose();
    _phoneController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text(Strings.tooltipAddGuest),
      content: Container(
        width: 600,
        child: Form(
          key: _formKey,
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              TextFormField(
                decoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: Strings.tableColName,
                ),
                controller: _fullNameController,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return Strings.errorTextField;
                  }
                  return null;
                },
              ),
              const SizedBox(
                height: 16,
              ),
              TextFormField(
                decoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: Strings.tableColTelegram,
                ),
                controller: _telegramController,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return Strings.errorTextField;
                  }
                  return null;
                },
              ),
              const SizedBox(
                height: 16,
              ),
              TextFormField(
                decoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: Strings.tableColPhone,
                ),
                controller: _phoneController,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return Strings.errorTextField;
                  }
                  return null;
                },
              ),
              const SizedBox(
                height: 16,
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  const Text(Strings.tableColGender),
                  SizedBox(
                    width: 300,
                    child: DropdownButtonFormField(
                      value: gender,
                      items: GuestGender.values
                          .map((e) => DropdownMenuItem(
                              value: e, child: Text(Strings.getGuestGender(e))))
                          .toList(),
                      onChanged: (value) {
                        if (value != null) {
                          gender = value;
                        }
                      },
                      validator: (value) {
                        if (value == null || value == GuestGender.none) {
                          return Strings.errorTextField;
                        }
                        return null;
                      },
                    ),
                  ),
                ],
              ),
              if (paymentStatus != PaymentStatus.none)
                const SizedBox(
                  height: 16,
                ),
              if (paymentStatus != PaymentStatus.none)
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    const Text(Strings.tableColPayment),
                    SizedBox(
                      width: 300,
                      child: DropdownButtonFormField(
                        value: paymentStatus,
                        items: PaymentStatus.values
                            .map((e) => DropdownMenuItem(
                                value: e, child: Text(Strings.getPaymentStatus(e))))
                            .toList(),
                        onChanged: (value) {
                          if (value != null) {
                            paymentStatus = value;
                          }
                        },
                        validator: (value) {
                          if (value == null || value == PaymentStatus.none) {
                            return Strings.errorTextField;
                          }
                          return null;
                        },
                      ),
                    ),
                  ],
                ),
              const SizedBox(
                height: 16,
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  const Text(Strings.tableColProgram),
                  SizedBox(
                    width: 300,
                    child: DropdownButtonFormField(
                      value: program,
                      items: EducationalProgram.values
                          .map((e) => DropdownMenuItem(
                              value: e, child: Text(Strings.getProgramName(e))))
                          .toList(),
                      onChanged: (value) {
                        if (value != null) {
                          program = value;
                        }
                      },
                      validator: (value) {
                        if (value == null || value == EducationalProgram.none) {
                          return Strings.errorTextField;
                        }
                        return null;
                      },
                    ),
                  ),
                ],
              ),
              const SizedBox(
                height: 16,
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  const Text(Strings.tableColTicket),
                  SizedBox(
                    width: 300,
                    child: DropdownButtonFormField(
                      value: ticket,
                      items: TicketType.values
                          .map((e) => DropdownMenuItem(
                              value: e, child: Text(Strings.getEventTicketType(e))))
                          .toList(),
                      onChanged: (value) {
                        if (value != null) {
                          ticket = value;
                        }
                      },
                      validator: (value) {
                        if (value == null || value == TicketType.none) {
                          return Strings.errorTextField;
                        }
                        return null;
                      },
                    ),
                  ),
                ],
              ),
              const SizedBox(
                height: 16,
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  const Text(Strings.tableColIsLegalAge),
                  ValueListenableBuilder(
                    valueListenable: isLegalAge,
                    builder: (context, value, child) => Checkbox(
                      value: isLegalAge.value,
                      onChanged: (value) {
                        if (value != null) {
                          isLegalAge.value = value;
                        }
                      },
                    ),
                  ),
                ],
              ),
              const SizedBox(
                height: 16,
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  const Text(Strings.tableColNeedsTransfer),
                  ValueListenableBuilder(
                    valueListenable: needsTransfer,
                    builder: (context, value, child) => Checkbox(
                      value: needsTransfer.value,
                      onChanged: (value) {
                        if (value != null) {
                          needsTransfer.value = value;
                        }
                      },
                    ),
                  ),
                ],
              ),
            ],
          ),
        ),
      ),
      actions: [
        TextButton(
          onPressed: () {
            Navigator.of(context).pop();
          },
          child: const Text(Strings.cancel),
        ),
        if (widget.guest != null)
          TextButton(
            onPressed: () {
              ref
                  .read(eventGuestsProvider(widget.uWave).notifier)
                  .delete(widget.guest!.id);
              Navigator.of(context).pop();
            },
            child: const Text(
              Strings.delete,
              style: TextStyle(color: Colors.red),
            ),
          ),
        TextButton(
            onPressed: () {
              if (_formKey.currentState!.validate()) {
                EventGuest newGuest = EventGuest(
                  id: widget.guest?.id ?? "id",
                  fullName: _fullNameController.text,
                  gender: gender,
                  telegram: _telegramController.text,
                  paymentInfo: EventGuestPaymentInfo(
                      status: paymentStatus,
                      auditRecords:
                          widget.guest?.paymentInfo.auditRecords ?? []),
                  program: program,
                  phone: _phoneController.text,
                  isLegalAge: isLegalAge.value,
                  ticket: ticket,
                  needsTransfer: needsTransfer.value,
                );
                if (widget.guest == null) {
                  ref
                      .read(eventGuestsProvider(widget.uWave).notifier)
                      .add(newGuest);
                } else {
                  ref
                      .read(eventGuestsProvider(widget.uWave).notifier)
                      .updateGuest(newGuest);
                }
                Navigator.of(context).pop();
              }
            },
            child: Text(widget.guest == null ? Strings.create : Strings.save)),
      ],
    );
  }
}
