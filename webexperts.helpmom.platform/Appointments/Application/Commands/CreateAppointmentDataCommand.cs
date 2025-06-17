
namespace webexperts.helpmom.platform.Appointments.Application.Commands;

public class CreateAppointmentDataCommand
{
    public int DoctorId { get; set; }
    public string DoctorName { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public string Description { get; set; }
    public int PatientId { get; set; }
    public string PatientName { get; set; }
}