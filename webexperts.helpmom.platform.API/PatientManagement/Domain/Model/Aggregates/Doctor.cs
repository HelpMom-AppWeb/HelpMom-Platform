using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;

public partial class Doctor
{
    public int Id { get; set; }
    public ProfileId? ProfileId { get; set; }
    //public string Name { get; set; } = string.Empty;
    //public string Email { get; set; } = string.Empty;
    
    public ICollection<Patient> Patients { get; set; }
    
    public Doctor()
    {
        Patients = new List<Patient>();
    }
}