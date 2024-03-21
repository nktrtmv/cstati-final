using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Events.Contracts.Events.Statuses;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Queries.GetAll.Contracts.Events;

internal static class GetAllCstatiEventsQueryResponseEventBffConverter
{
    internal static GetAllCstatiEventsQueryResponseEventBff FromDto(GetAllCstatiEventsQueryResponseEvent @event)
    {
        CstatiEventStatusBff status = CstatiEventStatusBffConverter.FromDto(@event.Status);

        var result = new GetAllCstatiEventsQueryResponseEventBff
        {
            Id = @event.Id,
            Name = @event.Name,
            Status = status
        };

        return result;
    }
}
