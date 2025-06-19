namespace webexperts.helpmom.platform.API.Interfaces.REST.Resources;

public class CreateMedicationResource
{
    
    public string Name { get; set; }
    public string Presentation { get; set; }
    public string Manufacturer { get; set; }
    public Guid PrescriptionId { get; set; }
    
}