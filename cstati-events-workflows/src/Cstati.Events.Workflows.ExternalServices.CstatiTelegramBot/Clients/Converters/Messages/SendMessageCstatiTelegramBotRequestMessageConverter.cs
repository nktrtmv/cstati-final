using Cstati.Events.Workflows.ExternalServices.CstatiTelegramBot.Contracts.Messages;
using Cstati.Telegram.Bot.Api;

namespace Cstati.Events.Workflows.ExternalServices.CstatiTelegramBot.Clients.Converters.Messages;

internal static class SendMessageCstatiTelegramBotRequestMessageConverter
{
    internal static SendMessageCstatiTelegramBotRequestMessage FromExternal(CstatiTelegramBotMessageExternal message)
    {
        var result = new SendMessageCstatiTelegramBotRequestMessage
        {
            RecipientLogin = message.RecipientLogin,
            Message = message.Message
        };

        return result;
    }
}
