namespace webexperts.helpmom.platform.API.Domain.Model.Entities;
    
    public class Frequency
    {
        public string Value { get; private set; }
    
        public Frequency(string value = "")
        {
            Value = value;
        }
    }