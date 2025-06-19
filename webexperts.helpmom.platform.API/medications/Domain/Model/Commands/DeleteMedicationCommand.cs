namespace webexperts.helpmom.platform.API.Domain.Model.Commands;
        
        public class DeleteMedicationCommand
        {
            public Guid MedicationId { get; }
        
            public DeleteMedicationCommand(Guid medicationId)
            {
                MedicationId = medicationId;
            }
        }