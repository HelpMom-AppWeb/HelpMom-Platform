using System.Text.RegularExpressions;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;

public class EmailAdress
{
    public string Value { get; }

    private static readonly Regex EmailRegex = new Regex(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$", 
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public EmailAdress(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be empty.");

        if (!EmailRegex.IsMatch(value))
            throw new ArgumentException("Email does not have a valid format.");

        Value = value;
    }

    public override string ToString() => Value;
}