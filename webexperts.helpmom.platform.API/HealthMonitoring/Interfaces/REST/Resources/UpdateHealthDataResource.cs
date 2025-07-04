namespace webexperts.helpmom.platform.API.HealthMonitoring.Interfaces.REST.Resources;

public record UpdateHealthDataResource(int HeartRate,
    decimal Temperature,
    decimal Weight,
    int OxygenSaturation);