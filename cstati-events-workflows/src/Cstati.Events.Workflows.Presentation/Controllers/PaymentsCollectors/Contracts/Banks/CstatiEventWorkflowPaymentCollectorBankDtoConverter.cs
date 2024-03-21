using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Contracts.Banks;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Contracts.Banks;

internal static class CstatiEventWorkflowPaymentCollectorBankDtoConverter
{
    internal static CstatiEventWorkflowPaymentCollectorBankDto FromInternal(CstatiEventWorkflowPaymentCollectorBankInternal bank)
    {
        CstatiEventWorkflowPaymentCollectorBankDto result = bank switch
        {
            CstatiEventWorkflowPaymentCollectorBankInternal.Tinkoff => CstatiEventWorkflowPaymentCollectorBankDto.Tinkoff,
            CstatiEventWorkflowPaymentCollectorBankInternal.Alpha => CstatiEventWorkflowPaymentCollectorBankDto.Alpha,
            CstatiEventWorkflowPaymentCollectorBankInternal.Sber => CstatiEventWorkflowPaymentCollectorBankDto.Sber,
            CstatiEventWorkflowPaymentCollectorBankInternal.Vtb => CstatiEventWorkflowPaymentCollectorBankDto.Vtb,
            CstatiEventWorkflowPaymentCollectorBankInternal.Ozon => CstatiEventWorkflowPaymentCollectorBankDto.Ozon,
            CstatiEventWorkflowPaymentCollectorBankInternal.Yandex => CstatiEventWorkflowPaymentCollectorBankDto.Yandex,
            _ => throw new ArgumentTypeOutOfRangeException(bank)
        };

        return result;
    }

    internal static CstatiEventWorkflowPaymentCollectorBankInternal ToInternal(CstatiEventWorkflowPaymentCollectorBankDto bank)
    {
        CstatiEventWorkflowPaymentCollectorBankInternal result = bank switch
        {
            CstatiEventWorkflowPaymentCollectorBankDto.Tinkoff => CstatiEventWorkflowPaymentCollectorBankInternal.Tinkoff,
            CstatiEventWorkflowPaymentCollectorBankDto.Alpha => CstatiEventWorkflowPaymentCollectorBankInternal.Alpha,
            CstatiEventWorkflowPaymentCollectorBankDto.Sber => CstatiEventWorkflowPaymentCollectorBankInternal.Sber,
            CstatiEventWorkflowPaymentCollectorBankDto.Vtb => CstatiEventWorkflowPaymentCollectorBankInternal.Vtb,
            CstatiEventWorkflowPaymentCollectorBankDto.Ozon => CstatiEventWorkflowPaymentCollectorBankInternal.Ozon,
            CstatiEventWorkflowPaymentCollectorBankDto.Yandex => CstatiEventWorkflowPaymentCollectorBankInternal.Yandex,
            _ => throw new ArgumentTypeOutOfRangeException(bank)
        };

        return result;
    }
}
