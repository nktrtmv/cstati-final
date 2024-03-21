using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Commands.Create.Contracts;

internal static class CreateCstatiEventsCommandResponseBffConverter
{
    internal static CreateCstatiEventsCommandResponseBff FromDto(CreateCstatiEventsCommandResponse response)
    {
        var result = new CreateCstatiEventsCommandResponseBff
        {
            EventId = response.EventId
        };

        return result;
    }
}
