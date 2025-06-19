namespace webexperts.helpmom.platform.API.Domain.Model.Queries;

public record CheckMedicationExistsInPrescriptionQuery(Guid PrescriptionId, Guid MedicationId);