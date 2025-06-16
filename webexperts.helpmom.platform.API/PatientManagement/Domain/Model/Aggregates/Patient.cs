using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Entities;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;

public partial class Patient
{
    public int Id { get; set; }
    public ProfileId? ProfileId { get; set; }
    //public string Name { get; set; }
    //public string Email { get; set; }
    //public string Phone { get; set; }
    public Baby? Baby { get; set; }
    public int AssignedDoctorId { get; set; }

    public Patient()
    {
        
    }
}