using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors.ValueObjects.Banks;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;

namespace Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Contracts.Banks;

internal static class CstatiEventWorkflowPaymentsCollectorBankInternalConverter
{
    internal static CstatiEventWorkflowPaymentCollectorBankInternal FromDomain(CstatiEventWorkflowPaymentCollectorBank bank)
    {
        CstatiEventWorkflowPaymentCollectorBankInternal result = bank switch
        {
            CstatiEventWorkflowPaymentCollectorBank.Tinkoff => CstatiEventWorkflowPaymentCollectorBankInternal.Tinkoff,
            CstatiEventWorkflowPaymentCollectorBank.Alpha => CstatiEventWorkflowPaymentCollectorBankInternal.Alpha,
            CstatiEventWorkflowPaymentCollectorBank.Sber => CstatiEventWorkflowPaymentCollectorBankInternal.Sber,
            CstatiEventWorkflowPaymentCollectorBank.Vtb => CstatiEventWorkflowPaymentCollectorBankInternal.Vtb,
            CstatiEventWorkflowPaymentCollectorBank.Ozon => CstatiEventWorkflowPaymentCollectorBankInternal.Ozon,
            CstatiEventWorkflowPaymentCollectorBank.Yandex => CstatiEventWorkflowPaymentCollectorBankInternal.Yandex,
            _ => throw new ArgumentTypeOutOfRangeException(bank)
        };

        return result;
    }

    internal static CstatiEventWorkflowPaymentCollectorBank ToDomain(CstatiEventWorkflowPaymentCollectorBankInternal bank)
    {
        CstatiEventWorkflowPaymentCollectorBank result = bank switch
        {
            CstatiEventWorkflowPaymentCollectorBankInternal.Tinkoff => CstatiEventWorkflowPaymentCollectorBank.Tinkoff,
            CstatiEventWorkflowPaymentCollectorBankInternal.Alpha => CstatiEventWorkflowPaymentCollectorBank.Alpha,
            CstatiEventWorkflowPaymentCollectorBankInternal.Sber => CstatiEventWorkflowPaymentCollectorBank.Sber,
            CstatiEventWorkflowPaymentCollectorBankInternal.Vtb => CstatiEventWorkflowPaymentCollectorBank.Vtb,
            CstatiEventWorkflowPaymentCollectorBankInternal.Ozon => CstatiEventWorkflowPaymentCollectorBank.Ozon,
            CstatiEventWorkflowPaymentCollectorBankInternal.Yandex => CstatiEventWorkflowPaymentCollectorBank.Yandex,
            _ => throw new ArgumentTypeOutOfRangeException(bank)
        };

        return result;
    }

    internal static string ToString(CstatiEventWorkflowPaymentCollectorBank bank)
    {
        string result = bank switch
        {
            CstatiEventWorkflowPaymentCollectorBank.Tinkoff => "Тинькофф",
            CstatiEventWorkflowPaymentCollectorBank.Alpha => "Альфа",
            CstatiEventWorkflowPaymentCollectorBank.Sber => "Сбер",
            CstatiEventWorkflowPaymentCollectorBank.Vtb => "ВТБ",
            CstatiEventWorkflowPaymentCollectorBank.Ozon => "Озон",
            CstatiEventWorkflowPaymentCollectorBank.Yandex => "Яндекс",
            _ => throw new ArgumentTypeOutOfRangeException(bank)
        };

        return result;
    }
}
