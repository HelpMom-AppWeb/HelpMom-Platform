namespace webexperts.helpmom.platform.Domain.Model.Queries;

public record GetPrescriptionByPatientIdQuery(int PatientId);

public record GetActivePrescriptionsByPatientIdQuery(int PatientId);

