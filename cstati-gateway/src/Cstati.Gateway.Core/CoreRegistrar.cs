using Cstati.Gateway.Core.Common.Persons.Services.Enrichers.Sources;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.AddAccess;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Authorize;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Create;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Delete;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.DeleteAccess;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Queries.GetAll;
using Cstati.Gateway.Core.CstatiEvents.Events.Commands.Create;
using Cstati.Gateway.Core.CstatiEvents.Events.Commands.Delete;
using Cstati.Gateway.Core.CstatiEvents.Events.Commands.Update;
using Cstati.Gateway.Core.CstatiEvents.Events.Queries.Get;
using Cstati.Gateway.Core.CstatiEvents.Events.Queries.GetAll;
using Cstati.Gateway.Core.CstatiEvents.Finances.Commands.ActualizeRevenue;
using Cstati.Gateway.Core.CstatiEvents.Finances.Commands.AddExpense;
using Cstati.Gateway.Core.CstatiEvents.Finances.Commands.DeleteExpense;
using Cstati.Gateway.Core.CstatiEvents.Finances.Queries.GetDetails;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Create;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Delete;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Update;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Queries.GetAll;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Add;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.AddBatch;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Delete;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.SendPaymentTelegramMessages;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.SendTelegramMessages;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Update;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Create;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Delete;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Update;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Commands.Create;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Commands.Delete;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Queries.GetAll;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Complete;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Create;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Delete;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Start;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Queries.GetAll;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers.Sources;

using Microsoft.Extensions.DependencyInjection;

namespace Cstati.Gateway.Core;

public static class CoreRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton<ISourceEnricher, PersonsSourceEnricher>();

        // accounts
        services.AddSingleton<AddAccessCstatiAccountsService>();
        services.AddSingleton<AuthorizeCstatiAccountsService>();
        services.AddSingleton<CreateCstatiAccountsService>();
        services.AddSingleton<DeleteCstatiAccountsService>();
        services.AddSingleton<DeleteAccessCstatiAccountsService>();
        services.AddSingleton<GetAllCstatiAccountsService>();

        // events
        services.AddSingleton<CreateCstatiEventsService>();
        services.AddSingleton<UpdateCstatiEventsService>();
        services.AddSingleton<DeleteCstatiEventsService>();
        services.AddSingleton<GetCstatiEventsService>();
        services.AddSingleton<GetAllCstatiEventsService>();

        // finances
        services.AddSingleton<AddExpenseCstatiEventsFinancesService>();
        services.AddSingleton<DeleteExpenseCstatiEventsFinancesService>();
        services.AddSingleton<ActualizeRevenueCstatiEventsFinancesService>();
        services.AddSingleton<GetDetailsCstatiEventsFinancesService>();

        // tasks
        services.AddSingleton<CreateCstatiEventsTasksService>();
        services.AddSingleton<DeleteCstatiEventsTasksService>();
        services.AddSingleton<UpdateCstatiEventsTasksService>();
        services.AddSingleton<GetAllCstatiEventsTasksService>();

        // guests
        services.AddSingleton<AddCstatiEventsWorkflowsGuestsService>();
        services.AddSingleton<AddBatchCstatiEventsWorkflowsGuestsService>();
        services.AddSingleton<DeleteCstatiEventsWorkflowsGuestsService>();
        services.AddSingleton<UpdateCstatiEventsWorkflowsGuestsService>();
        services.AddSingleton<SendTelegramMessagesCstatiEventsWorkflowsGuestsService>();
        services.AddSingleton<SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsService>();
        services.AddSingleton<GetAllCstatiEventsWorkflowsGuestsService>();

        // payments collectors
        services.AddSingleton<CreateCstatiEventsWorkflowsPaymentsCollectorsService>();
        services.AddSingleton<DeleteCstatiEventsWorkflowsPaymentsCollectorsService>();
        services.AddSingleton<UpdateCstatiEventsWorkflowsPaymentsCollectorsService>();
        services.AddSingleton<GetAllCstatiEventsWorkflowsPaymentsCollectorsService>();

        // tickets
        services.AddSingleton<CreateCstatiEventsWorkflowsTicketsService>();
        services.AddSingleton<DeleteCstatiEventsWorkflowsTicketsService>();
        services.AddSingleton<GetAllCstatiEventsWorkflowsTicketsService>();

        // waves
        services.AddSingleton<CreateCstatiEventsWorkflowsWavesService>();
        services.AddSingleton<DeleteCstatiEventsWorkflowsWavesService>();
        services.AddSingleton<CompleteCstatiEventsWorkflowsWavesService>();
        services.AddSingleton<StartCstatiEventsWorkflowsWavesService>();
        services.AddSingleton<GetAllCstatiEventsWorkflowsWavesService>();
    }
}
