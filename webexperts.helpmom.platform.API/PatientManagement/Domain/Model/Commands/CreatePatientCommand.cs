namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;

public record CreatePatientCommand(string Name, string Email, string Phone, int AssignedDoctorId, string BabyName, DateTime BabyDateOfBirth, string BabyGender);