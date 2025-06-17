namespace webexperts.helpmom.platform.API.Domain.Model.Entities;
    
    public class Duration
    {
        public string Value { get; private set; }
    
        public Duration(string value = "")
        {
            Value = value;
        }
    }