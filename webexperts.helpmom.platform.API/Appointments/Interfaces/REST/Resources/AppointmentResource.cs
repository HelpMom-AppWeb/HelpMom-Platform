namespace webexperts.helpmom.platform.API.Appointments.Interfaces.REST.Resources;

public record AppointmentResource(int doctorId, string doctorName, DateTime date, TimeSpan time, string description, int patientId, string patientName);