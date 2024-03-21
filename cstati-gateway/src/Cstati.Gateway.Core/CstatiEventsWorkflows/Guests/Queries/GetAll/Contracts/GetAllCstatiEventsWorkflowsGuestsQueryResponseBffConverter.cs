using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts.Guests;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsWorkflowsGuestsQueryResponseBffConverter
{
    internal static GetAllCstatiEventsWorkflowsGuestsQueryResponseBff FromDto(GetAllCstatiEventsWorkflowsGuestsQueryResponse response)
    {
        GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestBff[] guests =
            response.Guests.Select(GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestBffConverter.FromDto).ToArray();

        var result = new GetAllCstatiEventsWorkflowsGuestsQueryResponseBff
        {
            Guests = guests,
            ConcurrencyToken = response.ConcurrencyToken
        };

        return result;
    }
}
