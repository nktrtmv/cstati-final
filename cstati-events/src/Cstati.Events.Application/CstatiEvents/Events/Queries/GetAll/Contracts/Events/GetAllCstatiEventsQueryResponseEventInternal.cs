using Cstati.Events.Application.CstatiEvents.Events.Contracts.Events.Statuses;

namespace Cstati.Events.Application.CstatiEvents.Events.Queries.GetAll.Contracts.Events;

public sealed class GetAllCstatiEventsQueryResponseEventInternal
{
    internal GetAllCstatiEventsQueryResponseEventInternal(string id, string name, CstatiEventStatusInternal status)
    {
        Id = id;
        Name = name;
        Status = status;
    }

    public string Id { get; }
    public string Name { get; }
    public CstatiEventStatusInternal Status { get; }
}
