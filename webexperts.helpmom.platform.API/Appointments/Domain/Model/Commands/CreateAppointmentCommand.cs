namespace webexperts.helpmom.platform.API.Appointments.Domain.Model.Commands;

public record CreateAppointmentCommand(
    int DoctorId,
    string DoctorName,
    DateTime Date,
    TimeSpan Time,
    string Description,
    int PatientId,
    string PatientName
);