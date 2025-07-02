namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;

public class Phone
{
    public string Value { get; }

    public Phone(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El teléfono no puede estar vacío.");

        if (value.Length != 9)
            throw new ArgumentException("El teléfono debe tener exactamente 9 dígitos.");

        if (value[0] != '9')
            throw new ArgumentException("El teléfono debe comenzar con el dígito 9.");

        if (!value.All(char.IsDigit))
            throw new ArgumentException("El teléfono debe contener solo dígitos.");

        Value = value;
    }

    public override string ToString() => Value;
    
}