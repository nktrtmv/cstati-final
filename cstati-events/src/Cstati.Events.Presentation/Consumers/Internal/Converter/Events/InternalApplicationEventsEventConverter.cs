using Cstati.Events.Application.CstatiEvents.Events.Commands.ProcessApplicationEvents.Contracts;
using Cstati.Events.Presentation.Abstractions;

using MediatR;

namespace Cstati.Events.Presentation.Consumers.Internal.Converter.Events;

internal static class InternalApplicationEventsEventConverter
{
    internal static IRequest? ToInternal(InternalApplicationEventsEventValue @event)
    {
        IRequest? result = @event.CommandCase switch
        {
            InternalApplicationEventsEventValue.CommandOneofCase.Process => new ProcessApplicationEventsCommandInternal { EventId = @event.Process.EventId },

            _ => null
        };

        return result;
    }
}
