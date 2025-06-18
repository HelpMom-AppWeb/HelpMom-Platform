using webexperts.helpmom.platform.API.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.Domain.Model.Commands;
    
    public record CreateMedicationCommand
    {
        public CreateMedicationCommand(string name, string concentration, string dose, string via, Frequency frequency, Duration duration, Quantity quantity, string presentation, string manufacturer, Guid prescriptionId)
        {
            Name = name;
            Concentration = concentration;
            Dose = dose;
            Via = via;
            Frequency = frequency;
            Duration = duration;
            Quantity = quantity;
            Presentation = presentation;
            Manufacturer = manufacturer;
            PrescriptionId = prescriptionId;
        }

        public string Name { get; }
        public string Concentration { get; }
        public string Dose { get; }
        public string Via { get; }
        public Frequency Frequency { get; }
        public Duration Duration { get; }
        public Quantity Quantity { get; }
        public string Presentation { get; }
        public string Manufacturer { get; }
        public Guid PrescriptionId { get; }
    
    
    }