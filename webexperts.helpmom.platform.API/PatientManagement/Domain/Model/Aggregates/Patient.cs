using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Entities;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;

public partial class Patient
{
    public int Id { get; private set; }
    public Name Name { get; private set; }
    public EmailAdress Email { get; private set; }
    public Phone Phone { get; private set; }
    public Baby Baby { get; private set; }
    public Doctor AssignedDoctor { get; private set; }
    public AssignedDoctorId AssignedDoctorId { get; private set; }
    
    public Patient(CreatePatientCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        Name = new Name(command.Name);
        Email = new EmailAdress(command.Email);
        Phone = new Phone(command.Phone);
        Baby = new Baby(command.BabyName, command.BabyDateOfBirth, command.BabyGender);
        AssignedDoctorId = new AssignedDoctorId(command.AssignedDoctorId);
        AssignDoctor(new Doctor(command.AssignedDoctorId)); 
    }
    
    public void AssignDoctor(Doctor doctor)
    {
        AssignedDoctor = doctor ?? throw new ArgumentNullException(nameof(doctor));
        AssignedDoctorId = new AssignedDoctorId(doctor.Id);
    }
    
    
    
}