namespace Cstati.Events.Workflows.ExternalServices.CstatiTelegramBot.Contracts.Messages;

public sealed class CstatiTelegramBotMessageExternal
{
    public CstatiTelegramBotMessageExternal(string recipientLogin, string message)
    {
        RecipientLogin = recipientLogin;
        Message = message;
    }

    public string RecipientLogin { get; }
    public string Message { get; }
}
