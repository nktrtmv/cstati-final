using Cstati.Events.Application.CstatiEvents.Events.Queries.GetAll.Contracts.Events;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Presentation.Controllers.Events.Converters.Contracts.Statuses;

namespace Cstati.Events.Presentation.Controllers.Events.Converters.Queries.GetAll.Events;

internal static class GetAllCstatiEventsQueryResponseEventConverter
{
    internal static GetAllCstatiEventsQueryResponseEvent FromInternal(GetAllCstatiEventsQueryResponseEventInternal @event)
    {
        CstatiEventStatusDto status = CstatiEventStatusDtoConverter.FromInternal(@event.Status);

        var result = new GetAllCstatiEventsQueryResponseEvent
        {
            Id = @event.Id,
            Name = @event.Name,
            Status = status
        };

        return result;
    }
}
