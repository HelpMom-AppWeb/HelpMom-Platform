using webexperts.helpmom.platform.Chat.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.Chat.Domain.Model.Commands;

public record CreateMessageCommand(
    string Text,
    long Timestamp,
    From From,
    int PatientId
);