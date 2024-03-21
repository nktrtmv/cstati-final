using Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Queries.GetAll.Guests;

namespace Cstati.Events.Workflows.Presentation.Controllers.Guests.Queries.GetAll;

internal static class GetAllCstatiEventsWorkflowsGuestsQueryResponseConverter
{
    internal static GetAllCstatiEventsWorkflowsGuestsQueryResponse FromInternal(GetAllCstatiEventsWorkflowsGuestsQueryResponseInternal response)
    {
        GetAllCstatiEventsWorkflowsGuestsQueryResponseGuest[] guests =
            response.Guests.Select(GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestConverter.FromInternal).ToArray();

        var concurrencyToken = ConcurrencyTokenConverterTo.ToString(response.ConcurrencyToken);

        var result = new GetAllCstatiEventsWorkflowsGuestsQueryResponse
        {
            Guests = { guests },
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }
}
