using Cstati.Events.Application.CstatiEvents.Tasks.Queries.GetAll.Contracts;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Presentation.Controllers.Tasks.Converters.Queries.GetAll.Tasks;

namespace Cstati.Events.Presentation.Controllers.Tasks.Converters.Queries.GetAll;

internal static class GetAllCstatiEventsTasksQueryResponseConverter
{
    internal static GetAllCstatiEventsTasksQueryResponse FromInternal(GetAllCstatiEventsTasksQueryResponseInternal response)
    {
        GetAllCstatiEventsTasksQueryResponseTask[] tasks =
            response.Tasks.Select(GetAllCstatiEventsTasksQueryResponseTaskConverter.FromInternal).ToArray();

        var concurrencyToken = ConcurrencyTokenConverterTo.ToString(response.ConcurrencyToken);

        var result = new GetAllCstatiEventsTasksQueryResponse
        {
            Tasks = { tasks },
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }
}
