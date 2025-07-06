namespace webexperts.helpmom.platform.API.Chat.Interfaces.REST.Resources;

public class MessageResource
{
    public string Text { get; set; }
    public long Timestamp { get; set; }
    
    public int FromUserId { get; set; }
    public string FromRole { get; set; }
    public int PatientId { get; set; }
}