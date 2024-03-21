using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Queries.GetAll.Contracts.Tasks;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsTasksQueryResponseBffConverter
{
    internal static GetAllCstatiEventsTasksQueryResponseBff FromDto(GetAllCstatiEventsTasksQueryResponse response, EnrichersContext enrichers)
    {
        GetAllCstatiEventsTasksQueryResponseTaskBff[] tasks =
            response.Tasks.Select(t => GetAllCstatiEventsTasksQueryResponseTaskBffConverter.FromDto(t, enrichers)).ToArray();

        var result = new GetAllCstatiEventsTasksQueryResponseBff
        {
            Tasks = tasks,
            ConcurrencyToken = response.ConcurrencyToken
        };

        return result;
    }
}
