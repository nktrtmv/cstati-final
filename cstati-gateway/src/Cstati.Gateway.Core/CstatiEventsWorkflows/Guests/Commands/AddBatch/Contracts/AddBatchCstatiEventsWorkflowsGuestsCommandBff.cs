using Microsoft.AspNetCore.Http;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.AddBatch.Contracts;

public sealed class AddBatchCstatiEventsWorkflowsGuestsCommandBff
{
    public required string EventId { get; init; }
    public required IFormFile CsvFile { get; init; }
    public required string ConcurrencyToken { get; init; }
}
