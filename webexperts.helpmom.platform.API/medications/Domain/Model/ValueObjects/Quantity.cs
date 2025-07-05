namespace webexperts.helpmom.platform.API.Domain.Model.ValueObjects;

public record Quantity(decimal Amount, string Unit)
{
    public Quantity() : this(0, "mg") { }
    
    public override string ToString() => $"{Amount} {Unit}";
}