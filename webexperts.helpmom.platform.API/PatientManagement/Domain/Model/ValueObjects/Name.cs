using System.Text.RegularExpressions;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;

public class Name
{
    public string Value { get; }

    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("The name cannot be empty.");

        if (value.Length < 2 || value.Length > 100)
            throw new ArgumentException("The name can only have between 2 and 100 characters.");

        if (!IsValidName(value))
            throw new ArgumentException("The name has non-valid characters.");

        Value = value;
    }

    /// <summary>
    /// Function to validate the name format.
    /// </summary>
    /// <param name="name"></param>The name to validate. Only allows letters, spaces, hyphens, and apostrophes.
    /// <returns></returns>
    private bool IsValidName(string name)
    {
        var regex = new Regex(@"^[\p{L} \-']+$", RegexOptions.Compiled);
        return regex.IsMatch(name);
    }

    public override string ToString() => Value;
    
}