using Cstati.Events.Application.CstatiEvents.Events.Commands.Create.Contracts;
using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Controllers.Events.Converters.Commands.Create;

internal static class CreateCstatiEventsCommandConverter
{
    internal static CreateCstatiEventsCommandInternal ToInternal(CreateCstatiEventsCommand command)
    {
        var result = new CreateCstatiEventsCommandInternal(command.Name);

        return result;
    }
}
