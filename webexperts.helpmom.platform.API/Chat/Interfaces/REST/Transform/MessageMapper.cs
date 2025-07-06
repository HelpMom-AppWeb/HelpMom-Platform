using webexperts.helpmom.platform.API.Chat.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Chat.Domain.Model.ValueObjects;
using webexperts.helpmom.platform.API.Chat.Interfaces.REST.Resources;

namespace webexperts.helpmom.platform.API.Chat.Interfaces.REST.Transform;

public static class MessageMapper
{
    public static MessageResource ToResource(Message message)
    {
        return new MessageResource
        {
            Text = message.Text,
            Timestamp = message.Timestramp,
            FromUserId = message.From.UserId,
            FromRole = message.From.Role,
            PatientId = message.PatientId
        };
    }

    public static Message ToDomainModel(MessageResource resource)
    {
        var from = new From(resource.FromUserId, resource.FromRole);
        return new Message(
            text: resource.Text,
            timestramp: resource.Timestamp,
            from: from,
            patientId: resource.PatientId
        );
    }
}