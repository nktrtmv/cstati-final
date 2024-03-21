using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.Factories.ValueObjects.Context;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.EducationalProgram;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.Genders;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.Factories;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets.ValueObjects.Types;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.Factories;

public static class CstatiEventWorkflowGuestFactory
{
    public static CstatiEventWorkflowGuest CreateNew(CstatiEventWorkflowGuestCreationContext context)
    {
        var id = Guid.NewGuid().ToString();

        CstatiEventWorkflowGuestPaymentInfo paymentInfo = CstatiEventWorkflowGuestPaymentInfoFactory.CreateNew();

        var result = new CstatiEventWorkflowGuest(
            id,
            context.FullName,
            context.Gender,
            context.TelegramLogin,
            paymentInfo,
            context.EducationalProgram,
            context.PhoneNumber,
            context.IsLegalAge,
            context.PreferredTicketType,
            context.TransferIsRequested);

        return result;
    }

    public static CstatiEventWorkflowGuest CreateFrom(
        CstatiEventWorkflowGuest obsoleteGuest,
        string id,
        string fullName,
        CstatiEventWorkflowGuestGender gender,
        string telegramLogin,
        CstatiEventWorkflowGuestPaymentStatus paymentStatusChangeTo,
        CstatiEventWorkflowGuestEducationalProgram educationalProgram,
        string phoneNumber,
        bool isLegalAge,
        CstatiEventWorkflowTicketType ticketType,
        bool? transferIsRequired)
    {
        CstatiEventWorkflowGuestPaymentInfo paymentInfo =
            CstatiEventWorkflowGuestPaymentInfoFactory.CreateFrom(obsoleteGuest.PaymentInfo, paymentStatusChangeTo);

        var result = new CstatiEventWorkflowGuest(
            id,
            fullName,
            gender,
            telegramLogin,
            paymentInfo,
            educationalProgram,
            phoneNumber,
            isLegalAge,
            ticketType,
            transferIsRequired);

        return result;
    }

    public static CstatiEventWorkflowGuest CreateFrom(CstatiEventWorkflowGuest obsoleteGuest, CstatiEventWorkflowGuestPaymentStatus paymentStatusChangeTo)
    {
        CstatiEventWorkflowGuestPaymentInfo paymentInfo =
            CstatiEventWorkflowGuestPaymentInfoFactory.CreateFrom(obsoleteGuest.PaymentInfo, paymentStatusChangeTo);

        var result = new CstatiEventWorkflowGuest(
            obsoleteGuest.Id,
            obsoleteGuest.FullName,
            obsoleteGuest.Gender,
            obsoleteGuest.TelegramLogin,
            paymentInfo,
            obsoleteGuest.EducationalProgram,
            obsoleteGuest.PhoneNumber,
            obsoleteGuest.IsLegalAge,
            obsoleteGuest.TicketType,
            obsoleteGuest.TransferIsRequired);

        return result;
    }
}
