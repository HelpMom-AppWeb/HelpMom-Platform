namespace webexperts.helpmom.platform.API.Domain.Model.Entities;

public class Quantity
{
    public int Value { get; private set; }

    public Quantity(int value = 0)
    {
        if (value < 0) throw new ArgumentException("La cantidad no puede ser negativa.");
        Value = value;
    }
}