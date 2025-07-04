using webexperts.helpmom.platform.API.Chat.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.Chat.Domain.Model.Commands;
public record CreateMessageCommand(
    string Text,
    long Timestamp,
    From From,
    int PatientId
);