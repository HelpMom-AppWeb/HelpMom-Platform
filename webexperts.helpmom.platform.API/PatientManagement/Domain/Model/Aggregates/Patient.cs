using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Entities;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;

public partial class Patient
{
    public int Id { get; }
    public ProfileId ProfileId { get; set; }
    public string Phone { get; set; }
    public Baby Baby { get; internal set; }
    public Doctor AssignedDoctor { get; internal set; }
    public int AssignedDoctorId { get; set; }

    public Patient()
    {
        Phone = string.Empty;
    }

    public Patient(CreatePatientCommand command)
    {
        ProfileId = new ProfileId(command.ProfileId);
        Phone = command.Phone;
        Baby = new Baby(command.BabyName, command.BabyDateOfBirth, command.BabyGender);
        AssignedDoctorId = command.AssignedDoctorId;
    }
}