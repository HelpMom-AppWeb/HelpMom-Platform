namespace webexperts.helpmom.platform.Domain.Model.Commands;

public record CreatePrescriptionCommand(
    int PatientId,
    int DoctorId,
    string Notes
);