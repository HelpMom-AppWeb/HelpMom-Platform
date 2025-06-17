using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Entities;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;

public partial class Patient
{
    public int Id { get; }
    public ProfileId ProfileId { get; set; }
    public string Phone { get; set; }
    public Baby Baby { get; set; }
    
    public int BabyId { get; set; }
    public Doctor AssignedDoctor { get; set; }
    public int AssignedDoctorId { get; set; }

    public Patient()
    {
        // Parameterless constructor for EF Core
    }

    public Patient(CreatePatientCommand command)
    {
        ProfileId = new ProfileId(command.ProfileId);
        Phone = command.Phone;
        BabyId = command.BabyId;
        AssignedDoctorId = command.AssignedDoctorId;
    }
}