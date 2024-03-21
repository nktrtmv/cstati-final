using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Events.Commands.Create.Contracts;

public sealed class CreateCstatiEventsCommandInternal : IRequest<CreateCstatiEventsCommandResponseInternal>
{
    public CreateCstatiEventsCommandInternal(string name)
    {
        Name = name;
    }

    internal string Name { get; }
}
