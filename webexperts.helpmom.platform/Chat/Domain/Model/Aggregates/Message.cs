// Aggregates/Message.cs
using webexperts.helpmom.platform.Chat.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.Chat.Domain.Model.Aggregates
{
    public class Message
    {
        public string Text { get; private set; }
        public long Timestamp { get; private set; } // ← DEBE ser long
        public From From { get; private set; }
        public int PatientId { get; private set; }

        public Message(string text, long timestamp, From from, int patientId)
        {
            Text = text;
            Timestamp = timestamp;
            From = from;
            PatientId = patientId;
        }



        private Message()
        {
        }
    }
}

      

