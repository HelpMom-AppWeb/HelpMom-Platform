namespace webexperts.helpmom.platform.API.Interfaces.REST.Resources;

public class MedicationResource
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Presentation { get; set; }
    public string Manufacturer { get; set; }
    public Guid PrescriptionId { get; set; }

    // Constructor vacío
    public MedicationResource() { }

    // Constructor parametrizado
    public MedicationResource(Guid id, string name, string presentation, string manufacturer, Guid prescriptionId)
    {
        Id = id;
        Name = name;
        Presentation = presentation;
        Manufacturer = manufacturer;
        PrescriptionId = prescriptionId;
    }
}