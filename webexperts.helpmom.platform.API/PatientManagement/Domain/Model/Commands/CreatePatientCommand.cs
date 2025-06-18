namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;

public record CreatePatientCommand(int ProfileId, string Phone, int AssignedDoctorId, string BabyName, DateTime BabyDateOfBirth, string BabyGender);