namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;

public class AssignedDoctorId
{
    public int Value { get; }

    public AssignedDoctorId(int value)
    {
        if (value == 0)
            throw new ArgumentException("DoctorId cannot be 0.");

        Value = value;
    }

    public override string ToString() => Value.ToString();

    public override bool Equals(object? obj)
    {
        if (obj is AssignedDoctorId other)
            return Value == other.Value;
        return false;
    }

    public override int GetHashCode() => Value.GetHashCode();
}
