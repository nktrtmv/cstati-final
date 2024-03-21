using Cstati.Events.Application.CstatiEvents.Events.Contracts.Events.Statuses;
using Cstati.Events.GenericSubdomain.Dates;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Application.CstatiEvents.Events.Queries.Get.Contracts.Events;

public sealed class GetCstatiEventsQueryResponseEventInternal
{
    internal GetCstatiEventsQueryResponseEventInternal(
        string id,
        string name,
        string? excelSheetLink,
        CstatiEventStatusInternal status,
        UtcDateTime? date,
        string? location,
        int? expectedGuestsCount,
        ConcurrencyToken concurrencyToken)
    {
        Id = id;
        Name = name;
        ExcelSheetLink = excelSheetLink;
        Status = status;
        Date = date;
        Location = location;
        ExpectedGuestsCount = expectedGuestsCount;
        ConcurrencyToken = concurrencyToken;
    }

    public string Id { get; }
    public string Name { get; }
    public string? ExcelSheetLink { get; }
    public CstatiEventStatusInternal Status { get; }
    public UtcDateTime? Date { get; }
    public string? Location { get; }
    public int? ExpectedGuestsCount { get; }
    public ConcurrencyToken ConcurrencyToken { get; }
}
