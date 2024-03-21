using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.Common.Persons;
using Cstati.Gateway.Core.Common.Persons.Services.Enrichers.Targets;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Contracts.Tasks.Statuses;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Queries.GetAll.Contracts.Tasks;

internal static class GetAllCstatiEventsTasksQueryResponseTaskBffConverter
{
    internal static GetAllCstatiEventsTasksQueryResponseTaskBff FromDto(GetAllCstatiEventsTasksQueryResponseTask task, EnrichersContext enrichers)
    {
        PersonBff executor = PersonsTargetEnricher.Add(enrichers, task.ExecutorLogin);

        var deadline = task.Deadline.ToDateTime();

        CstatiEventTaskStatusBff status = CstatiEventTaskStatusBffConverter.FromDto(task.Status);

        var result = new GetAllCstatiEventsTasksQueryResponseTaskBff
        {
            Id = task.Id,
            Name = task.Name,
            Executor = executor,
            Description = task.Description,
            Deadline = deadline,
            Status = status
        };

        return result;
    }
}
