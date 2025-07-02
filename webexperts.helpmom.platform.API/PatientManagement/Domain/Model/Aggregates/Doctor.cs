using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;

public partial class Doctor
{
    public int Id { get; }
    public Name Name { get; private set; }
    public EmailAdress Email { get; private set; }
    
    public Doctor(CreateDoctorCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);
        
        Name = new Name(command.Name);
        Email = new EmailAdress(command.Email);
    }
}