using webexperts.helpmom.platform.API.Appointments.Domain.Model.Commands;

namespace webexperts.helpmom.platform.API.Appointments.Domain.Model.Aggregates;

public class Appointment
{
    public int Id { get; set; }
    public int DoctorId { get; private set; }
    public string DoctorName { get; private set; }
    public DateTime Date { get; private set; }
    public TimeSpan Time { get; private set; }
    public string Description { get; private set; }
    public int PatientId { get; private set; }
    public string PatientName { get; private set; }

    public Appointment(int doctorId, string doctorName, DateTime date, TimeSpan time, string description, int patientId, string patientName)
    {
        DoctorId = doctorId;
        DoctorName = doctorName;
        Date = date;
        Time = time;
        Description = description;
        PatientId = patientId;
        PatientName = patientName;
    }

    public Appointment(CreateAppointmentCommand command)
    {
        DoctorId = command.DoctorId;
        DoctorName = command.DoctorName;
        Date = command.Date;
        Time = command.Time;
        Description = command.Description;
        PatientId = command.PatientId;
        PatientName = command.PatientName;
    }
}