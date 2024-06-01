using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents;
using Cstati.Events.Domain.Entities.Events.ValueObjects.Info;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Domain.Entities.Events;

public sealed partial class CstatiEvent
{
    private readonly List<ApplicationEvent> _applicationEvents;

    public string Id { get; }
    public CstatiEventInfo Info { get; private set; }
    public CstatiEventState State { get; }
    public IReadOnlyCollection<ApplicationEvent> ApplicationEvents => _applicationEvents;
    public ConcurrencyToken ConcurrencyToken { get; }
}
