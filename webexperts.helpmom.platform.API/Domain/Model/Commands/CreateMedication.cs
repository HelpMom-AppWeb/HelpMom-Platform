namespace webexperts.helpmom.platform.API.Domain.Model.Commands;
    
    public class CreateMedicationCommand
    {
        public string Name { get; }
        public string Presentation { get; }
        public string Manufacturer { get; }
        public Guid PrescriptionId { get; }
    
        public CreateMedicationCommand(string name, string presentation, string manufacturer, Guid prescriptionId)
        {
            Name = name;
            Presentation = presentation;
            Manufacturer = manufacturer;
            PrescriptionId = prescriptionId;
        }
    }