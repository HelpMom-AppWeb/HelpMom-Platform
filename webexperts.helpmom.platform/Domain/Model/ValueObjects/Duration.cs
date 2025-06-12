namespace webexperts.helpmom.platform.Domain.Model.ValueObjects;

public record Duration(int Value, string Unit)
{
    public Duration() : this(0, "days") { }
    
    public override string ToString() => $"{Value} {Unit}";
}