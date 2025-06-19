namespace webexperts.helpmom.platform.Chat.Interfaces.REST.Resources;

public class MessageResource
{
    public int Id { get; set; }
    public string Text { get; set; }
    public long Timestamp { get; set; }
    public int PatientId { get; set; }

    public int FromUserId { get; set; }
    public string FromRole { get; set; }
}