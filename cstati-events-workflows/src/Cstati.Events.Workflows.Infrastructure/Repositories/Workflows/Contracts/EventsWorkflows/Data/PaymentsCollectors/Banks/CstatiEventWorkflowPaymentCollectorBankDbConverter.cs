using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors.ValueObjects.Banks;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.PaymentsCollectors.Banks;

internal static class CstatiEventWorkflowPaymentCollectorBankDbConverter
{
    internal static CstatiEventWorkflowPaymentCollectorBankDb FromDomain(CstatiEventWorkflowPaymentCollectorBank bank)
    {
        CstatiEventWorkflowPaymentCollectorBankDb result = bank switch
        {
            CstatiEventWorkflowPaymentCollectorBank.Tinkoff => CstatiEventWorkflowPaymentCollectorBankDb.Tinkoff,
            CstatiEventWorkflowPaymentCollectorBank.Alpha => CstatiEventWorkflowPaymentCollectorBankDb.Alpha,
            CstatiEventWorkflowPaymentCollectorBank.Sber => CstatiEventWorkflowPaymentCollectorBankDb.Sber,
            CstatiEventWorkflowPaymentCollectorBank.Vtb => CstatiEventWorkflowPaymentCollectorBankDb.Vtb,
            CstatiEventWorkflowPaymentCollectorBank.Ozon => CstatiEventWorkflowPaymentCollectorBankDb.Ozon,
            CstatiEventWorkflowPaymentCollectorBank.Yandex => CstatiEventWorkflowPaymentCollectorBankDb.Yandex,
            _ => throw new ArgumentTypeOutOfRangeException(bank)
        };

        return result;
    }

    internal static CstatiEventWorkflowPaymentCollectorBank ToDomain(CstatiEventWorkflowPaymentCollectorBankDb bank)
    {
        CstatiEventWorkflowPaymentCollectorBank result = bank switch
        {
            CstatiEventWorkflowPaymentCollectorBankDb.Tinkoff => CstatiEventWorkflowPaymentCollectorBank.Tinkoff,
            CstatiEventWorkflowPaymentCollectorBankDb.Alpha => CstatiEventWorkflowPaymentCollectorBank.Alpha,
            CstatiEventWorkflowPaymentCollectorBankDb.Sber => CstatiEventWorkflowPaymentCollectorBank.Sber,
            CstatiEventWorkflowPaymentCollectorBankDb.Vtb => CstatiEventWorkflowPaymentCollectorBank.Vtb,
            CstatiEventWorkflowPaymentCollectorBankDb.Ozon => CstatiEventWorkflowPaymentCollectorBank.Ozon,
            CstatiEventWorkflowPaymentCollectorBankDb.Yandex => CstatiEventWorkflowPaymentCollectorBank.Yandex,
            _ => throw new ArgumentTypeOutOfRangeException(bank)
        };

        return result;
    }
}
