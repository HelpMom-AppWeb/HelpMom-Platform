using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;

public partial class Doctor
{
    public int Id { get; }
    public ProfileId? ProfileId { get; set; }
    
    public Doctor()
    {
        
    }

    public Doctor(CreateDoctorCommand command) : this()
    {
        ProfileId = new ProfileId(command.ProfileId);
    }
}