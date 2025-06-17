namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;

public record CreatePatientCommand(int ProfileId, string Phone, int BabyId, int AssignedDoctorId);