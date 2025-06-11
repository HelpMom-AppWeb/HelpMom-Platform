namespace webexperts.helpmom.platform.Chat.Domain.Model.Aggregates;

public partial class MessageThread
{
    public MessageThread(string text,long timstamp,string user)
    {
        Text = text;
        Timestramp = timstamp;
        User = user;
        
    }
    public string Text { get; set; }
    public long Timestramp { get; set; }
    public string User { get; set; }
    
    
}