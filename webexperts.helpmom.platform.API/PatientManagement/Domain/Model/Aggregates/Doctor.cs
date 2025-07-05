using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;

public partial class Doctor
{
    public int Id { get; private set;}
    public string Name { get; set;}
    
    protected Doctor()
    {
        
    }

    public Doctor(CreateDoctorCommand command) : this()
    {
        Name = command.Name;
    }
}