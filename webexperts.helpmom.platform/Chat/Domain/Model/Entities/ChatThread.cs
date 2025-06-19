using webexperts.helpmom.platform.Chat.Domain.Model.Aggregates;

namespace webexperts.helpmom.platform.Chat.Domain.Model.Entities;

public class ChatThread
{
    public int Id { get; private set; }
    public int PatientId { get; private set; }
    public List<Message> Messages { get; private set; } = new();
}