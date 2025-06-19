namespace webexperts.helpmom.platform.API.Domain.Model.ValueObjects;

public record Duration(int Value, string Unit)
{
    public Duration() : this(0, "days") { }
    
    public override string ToString() => $"{Value} {Unit}";
}