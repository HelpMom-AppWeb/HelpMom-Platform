using webexperts.helpmom.platform.Chat.Domain.Model.Aggregates;

namespace webexperts.helpmom.platform.Chat.Domain.Services;

public class MessageDomainService
{
    public bool IsValid(Message message)
    {
        return !string.IsNullOrWhiteSpace(message.Text);
    }
}