using webexperts.helpmom.platform.API.Domain.Model.Commands;
using webexperts.helpmom.platform.API.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.Domain.Model.Entities;
            
            public class Medication
            {
                public Guid Id { get; private set; } // Cambiado de int a Guid
                public string Name { get; private set; }
                public string Concentration { get; private set; }
                public Quantity Quantity { get; private set; }
                public string Dose { get; private set; }
                public string Via { get; private set; }
                public Frequency Frequency { get; private set; }
                public Duration Duration { get; private set; }
                public Guid PrescriptionId { get; private set; } // Cambiado de int a Guid
                public string Presentation { get; private set; }
                public string Manufacturer { get; private set; }
            
                public Medication()
                {
                    Name = string.Empty;
                    Concentration = string.Empty;
                    Quantity = new Quantity();
                    Dose = string.Empty;
                    Via = string.Empty;
                    Frequency = new Frequency();
                    Duration = new Duration();
                    Presentation = string.Empty;
                    Manufacturer = string.Empty;
                }
            
                public Medication(string name, string concentration, Quantity quantity,
                    string dose, string via, Frequency frequency, Duration duration,
                    Guid prescriptionId, string presentation, string manufacturer)
                {
                    Name = name;
                    Concentration = concentration;
                    Quantity = quantity;
                    Dose = dose;
                    Via = via;
                    Frequency = frequency;
                    Duration = duration;
                    PrescriptionId = prescriptionId;
                    Presentation = presentation;
                    Manufacturer = manufacturer;
                }
            
                public void UpdateMedication(string name, string concentration, Quantity quantity,
                    string dose, string via, Frequency frequency, Duration duration,
                    string presentation, string manufacturer)
                {
                    Name = name;
                    Concentration = concentration;
                    Quantity = quantity;
                    Dose = dose;
                    Via = via;
                    Frequency = frequency;
                    Duration = duration;
                    Presentation = presentation;
                    Manufacturer = manufacturer;
                }
                public Medication (CreateMedicationCommand command)
                {
                   
                    Name = command.Name;
                    Concentration = command.Concentration;
                    Quantity = command.Quantity;
                    Dose = command.Dose;
                    Via = command.Via;
                    Frequency = command.Frequency;
                    Duration = command.Duration;
                    PrescriptionId = command.PrescriptionId;
                    Presentation = command.Presentation;
                    Manufacturer = command.Manufacturer;
                }
            }