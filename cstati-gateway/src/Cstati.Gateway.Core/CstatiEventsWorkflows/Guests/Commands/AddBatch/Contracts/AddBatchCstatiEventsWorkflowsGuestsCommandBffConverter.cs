using System.Globalization;

using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.AddBatch.Contracts.Guests;

using CsvHelper;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.AddBatch.Contracts;

internal static class AddBatchCstatiEventsWorkflowsGuestsCommandBffConverter
{
    internal static AddCstatiEventsWorkflowsGuestsCommand ToDto(AddBatchCstatiEventsWorkflowsGuestsCommandBff command)
    {
        if (command.CsvFile.Length == 0)
        {
            throw new ApplicationException("Empty csv to add guests");
        }

        List<AddBatchCstatiEventsWorkflowsGuestsCommandGuestBff> guestsBff;

        using var reader = new StreamReader(command.CsvFile.OpenReadStream());

        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            guestsBff = csv.GetRecords<AddBatchCstatiEventsWorkflowsGuestsCommandGuestBff>().ToList();
        }

        AddCstatiEventsWorkflowsGuestsCommandGuest[] guests =
            guestsBff.Select(AddBatchCstatiEventsWorkflowsGuestsCommandGuestBffConverter.ToDto).ToArray();

        var result = new AddCstatiEventsWorkflowsGuestsCommand
        {
            EventId = command.EventId,
            Guests = { guests },
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
