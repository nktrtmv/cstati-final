using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Contracts.PaymentsCollectors.Banks;

internal static class CstatiEventWorkflowPaymentCollectorBankBffConverter
{
    internal static CstatiEventWorkflowPaymentCollectorBankBff FromDto(CstatiEventWorkflowPaymentCollectorBankDto bank)
    {
        CstatiEventWorkflowPaymentCollectorBankBff result = bank switch
        {
            CstatiEventWorkflowPaymentCollectorBankDto.Tinkoff => CstatiEventWorkflowPaymentCollectorBankBff.Tinkoff,
            CstatiEventWorkflowPaymentCollectorBankDto.Alpha => CstatiEventWorkflowPaymentCollectorBankBff.Alpha,
            CstatiEventWorkflowPaymentCollectorBankDto.Sber => CstatiEventWorkflowPaymentCollectorBankBff.Sber,
            CstatiEventWorkflowPaymentCollectorBankDto.Vtb => CstatiEventWorkflowPaymentCollectorBankBff.Vtb,
            CstatiEventWorkflowPaymentCollectorBankDto.Ozon => CstatiEventWorkflowPaymentCollectorBankBff.Ozon,
            CstatiEventWorkflowPaymentCollectorBankDto.Yandex => CstatiEventWorkflowPaymentCollectorBankBff.Yandex,
            _ => throw new ArgumentTypeOutOfRangeException(bank)
        };

        return result;
    }

    internal static CstatiEventWorkflowPaymentCollectorBankDto ToDto(CstatiEventWorkflowPaymentCollectorBankBff bank)
    {
        CstatiEventWorkflowPaymentCollectorBankDto result = bank switch
        {
            CstatiEventWorkflowPaymentCollectorBankBff.Tinkoff => CstatiEventWorkflowPaymentCollectorBankDto.Tinkoff,
            CstatiEventWorkflowPaymentCollectorBankBff.Alpha => CstatiEventWorkflowPaymentCollectorBankDto.Alpha,
            CstatiEventWorkflowPaymentCollectorBankBff.Sber => CstatiEventWorkflowPaymentCollectorBankDto.Sber,
            CstatiEventWorkflowPaymentCollectorBankBff.Vtb => CstatiEventWorkflowPaymentCollectorBankDto.Vtb,
            CstatiEventWorkflowPaymentCollectorBankBff.Ozon => CstatiEventWorkflowPaymentCollectorBankDto.Ozon,
            CstatiEventWorkflowPaymentCollectorBankBff.Yandex => CstatiEventWorkflowPaymentCollectorBankDto.Yandex,
            _ => throw new ArgumentTypeOutOfRangeException(bank)
        };

        return result;
    }
}
