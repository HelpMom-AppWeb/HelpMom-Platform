namespace webexperts.helpmom.platform.API.Domain.Model.Commands;

public record CreatePrescriptionCommand(
    int PatientId,
    int DoctorId,
    string Notes
);