using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Events.Commands.Create.Contracts;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Commands.Create;

public sealed class CreateCstatiEventsService : CstatiEventsServiceClientBase
{
    public CreateCstatiEventsService(CstatiEventsService.CstatiEventsServiceClient events) : base(events)
    {
    }

    public async Task<CreateCstatiEventsCommandResponseBff> Create(CreateCstatiEventsCommandBff commandBff, CancellationToken cancellationToken)
    {
        CreateCstatiEventsCommand command = CreateCstatiEventsCommandBffConverter.ToDto(commandBff);

        CreateCstatiEventsCommandResponse response = await Events.CreateAsync(command, cancellationToken: cancellationToken);

        CreateCstatiEventsCommandResponseBff result = CreateCstatiEventsCommandResponseBffConverter.FromDto(response);

        return result;
    }
}
