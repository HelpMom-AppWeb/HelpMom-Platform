using webexperts.helpmom.platform.API.Chat.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.Chat.Domain.Model.Aggregates
{
    public class Message
    {
        public int Id { get; private set; }
        public From From { get; private set; }
        public string Text { get; private set; }
        public long Timestramp { get; private set; }
        public int patientId { get; private set; }

        public Message(string text, long timestramp, From from, int patientId)
        {
            Text = text;
            Timestramp = timestramp;
            From = from;
            this.patientId = patientId;
        }

        // Constructor para EF
        private Message() { }
    }
}