using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.Common.Persons;
using Cstati.Gateway.Core.Common.Persons.Services.Enrichers.Targets;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Contracts.PaymentsCollectors.Banks;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentsCollectors.Guests;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentsCollectors;

internal static class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorBffConverter
{
    internal static GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorBff FromDto(
        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollector collector,
        EnrichersContext enrichers)
    {
        PersonBff person = PersonsTargetEnricher.Add(enrichers, collector.PersonLogin);

        CstatiEventWorkflowPaymentCollectorBankBff bank =
            CstatiEventWorkflowPaymentCollectorBankBffConverter.FromDto(collector.PreferredBank);

        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestBff[] guests =
            collector.Guests.Select(GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestBffConverter.FromDto).ToArray();

        var result = new GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorBff
        {
            Person = person,
            PreferredBank = bank,
            PhoneNumber = collector.PhoneNumber,
            CardNumber = collector.CardNumber,
            Guests = guests
        };

        return result;
    }
}
