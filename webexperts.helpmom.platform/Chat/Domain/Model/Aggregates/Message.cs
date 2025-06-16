// Aggregates/Message.cs
using webexperts.helpmom.platform.Chat.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.Chat.Domain.Model.Aggregates
{
    public class Message
    {
        public int Id { get; private set; }

        public From From { get; private set; }

        public string Text { get; private set; }

        public long Timestamp { get; private set; }

        public string PatientId { get; private set; }

        public Message(From from, string text, long timestamp, string patientId)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Timestamp = timestamp;
            PatientId = patientId ?? throw new ArgumentNullException(nameof(patientId));
        }

        private Message() { }
    }
}