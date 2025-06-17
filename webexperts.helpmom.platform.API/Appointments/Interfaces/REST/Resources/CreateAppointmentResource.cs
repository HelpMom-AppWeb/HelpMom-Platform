namespace webexperts.helpmom.platform.API.Appointments.Interfaces.REST.Resources;

public record CreateAppointmentResource(int DoctorId, string DoctorName, DateTime Date, TimeSpan Time, string Description, int PatientId, string PatientName);