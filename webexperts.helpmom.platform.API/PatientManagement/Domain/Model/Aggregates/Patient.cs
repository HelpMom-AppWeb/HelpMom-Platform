using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;

public partial class Patient
{
    public int Id { get; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Baby Baby { get; internal set; }
    public int AssignedDoctorId { get; set; }

    protected Patient()
    {

    }

    public Patient(CreatePatientCommand command)
    {
        Name = command.Name;
        Email = command.Email;
        Phone = command.Phone;
        Baby = new Baby(command.BabyName, command.BabyDateOfBirth, command.BabyGender);
        AssignedDoctorId = command.AssignedDoctorId;
    }
}