using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Commands.Create.Contracts;

internal static class CreateCstatiEventsCommandBffConverter
{
    internal static CreateCstatiEventsCommand ToDto(CreateCstatiEventsCommandBff command)
    {
        var result = new CreateCstatiEventsCommand
        {
            Name = command.Name
        };

        return result;
    }
}
