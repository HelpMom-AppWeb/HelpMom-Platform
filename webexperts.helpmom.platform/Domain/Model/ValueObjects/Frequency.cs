namespace webexperts.helpmom.platform.Domain.Model.ValueObjects;

public record Frequency(int TimesPerDay, string Schedule)
{
    public Frequency() : this(1, "Once daily") { }
    
    public override string ToString() => $"{TimesPerDay}x - {Schedule}";
}