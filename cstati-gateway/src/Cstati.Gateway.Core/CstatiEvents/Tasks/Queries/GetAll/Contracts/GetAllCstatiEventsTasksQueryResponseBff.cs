using Cstati.Gateway.Core.CstatiEvents.Tasks.Queries.GetAll.Contracts.Tasks;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsTasksQueryResponseBff
{
    public required GetAllCstatiEventsTasksQueryResponseTaskBff[] Tasks { get; init; }
    public required string ConcurrencyToken { get; init; }
}
