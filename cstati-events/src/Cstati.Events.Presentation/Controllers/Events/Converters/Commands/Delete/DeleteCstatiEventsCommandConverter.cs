using Cstati.Events.Application.CstatiEvents.Events.Commands.Delete.Contracts;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Controllers.Events.Converters.Commands.Delete;

internal static class DeleteCstatiEventsCommandConverter
{
    internal static DeleteCstatiEventsCommandInternal ToInternal(DeleteCstatiEventsCommand command)
    {
        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new DeleteCstatiEventsCommandInternal(command.EventId, concurrencyToken);

        return result;
    }
}
