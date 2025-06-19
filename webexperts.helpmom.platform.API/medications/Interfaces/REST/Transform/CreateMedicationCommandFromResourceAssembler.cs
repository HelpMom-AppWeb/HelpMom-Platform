namespace webexperts.helpmom.platform.API.Interfaces.REST.Transform;
        
        public class CreateMedicationCommandFromResourceAssembler
        {
            public string Name { get; }
            public string Presentation { get; }
            public string Manufacturer { get; }
            public Guid PrescriptionId { get; }
            public string Dosage { get; }
            public string Frequency { get; }
            public string Duration { get; }
            public string Notes { get; }
            public DateTime StartDate { get; }
            public DateTime EndDate { get; }
            public Guid MedicationId { get; }
        
            public CreateMedicationCommandFromResourceAssembler(
                string name,
                string presentation,
                string manufacturer,
                Guid prescriptionId,
                string dosage,
                string frequency,
                string duration,
                string notes,
                DateTime startDate,
                DateTime endDate,
                Guid medicationId)
            {
                Name = name;
                Presentation = presentation;
                Manufacturer = manufacturer;
                PrescriptionId = prescriptionId;
                Dosage = dosage;
                Frequency = frequency;
                Duration = duration;
                Notes = notes;
                StartDate = startDate;
                EndDate = endDate;
                MedicationId = medicationId;
            }
        }