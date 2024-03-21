using Cstati.Events.Application.CstatiEvents.Events.Commands.Create.Contracts;
using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Controllers.Events.Converters.Commands.Create;

internal static class CreateCstatiEventsCommandResponseConverter
{
    internal static CreateCstatiEventsCommandResponse FromInternal(CreateCstatiEventsCommandResponseInternal response)
    {
        var result = new CreateCstatiEventsCommandResponse
        {
            EventId = response.EventId
        };

        return result;
    }
}
