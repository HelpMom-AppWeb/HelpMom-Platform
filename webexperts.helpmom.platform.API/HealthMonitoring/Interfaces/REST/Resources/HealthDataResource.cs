namespace webexperts.helpmom.platform.API.HealthMonitoring.Interfaces.REST.Resources;

public record HealthDataResource(int Id, int HeartRate, decimal Temperature, decimal Weight, int OxygenSaturation, int PatientId, DateTimeOffset? CreatedAt,
    DateTimeOffset? UpdatedAt);