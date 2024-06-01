using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks.ValueObjects.Statuses;
using Cstati.Events.GenericSubdomain.Dates;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks;

public sealed partial class CstatiEventTask
{
    public string Id { get; }
    public string Name { get; }
    public string ExecutorLogin { get; }
    public string Description { get; }
    public UtcDateTime? Deadline { get; }
    public CstatiEventTaskStatus Status { get; }
}
