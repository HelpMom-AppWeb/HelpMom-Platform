namespace webexperts.helpmom.platform.Chat.Domain.Model.Commands;

public record CreateMessageCommand(
    int UserId,
    string Role,
    string Text,
    long Timestamp,
    string PatientId
);