using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;

public partial class Doctor
{
    public int Id { get; }
    public ProfileId ProfileId { get; set; }
    
    public ICollection<Patient> Patients { get; set; }
    
    public Doctor()
    {
        Patients = new List<Patient>();
    }

    public Doctor(CreateDoctorCommand command)
    {
        ProfileId = new ProfileId(command.ProfileId);
        Patients = new List<Patient>();
    }
}