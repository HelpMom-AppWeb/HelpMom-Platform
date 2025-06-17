namespace webexperts.helpmom.platform.Appointments.Domain.Model.Aggregates;

public class Appointment
{
    public string Id { get; private set; }
    public int DoctorId { get; private set; }
    public string DoctorName { get; private set; }
    public DateTime Date { get; private set; }
    public TimeSpan Time { get; private set; }
    public string Description { get; private set; }
    public int PatientId { get; private set; }
    public string PatientName { get; private set; }

    // Constructor privado para usar desde el método de creación
    private Appointment() { }

    // Método de creación
    public static Appointment Create(
        int doctorId, string doctorName, DateTime date, TimeSpan time, string description,
        int patientId, string patientName)
    {
        // Validaciones
        if (date < DateTime.Today)
            throw new ArgumentException("La fecha no puede ser en el pasado");
        
        if (string.IsNullOrEmpty(doctorName))
            throw new ArgumentException("El nombre del doctor es requerido");

        return new Appointment
        {
            Id = Guid.NewGuid().ToString(),
            DoctorId = doctorId,
            DoctorName = doctorName,
            Date = date,
            Time = time,
            Description = description,
            PatientId = patientId,
            PatientName = patientName
        };
    }
}