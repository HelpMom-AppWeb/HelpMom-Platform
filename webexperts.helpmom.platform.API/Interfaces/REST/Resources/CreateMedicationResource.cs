namespace webexperts.helpmom.platform.API.Interfaces.REST.Resources;

public class CreateMedicationResource
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Presentation { get; set; }
    public string Manufacturer { get; set; }
    public Guid PrescriptionId { get; set; }
    
}