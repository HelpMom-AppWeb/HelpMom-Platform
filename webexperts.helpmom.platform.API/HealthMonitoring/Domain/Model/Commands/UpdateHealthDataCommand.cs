namespace webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Commands;

public record UpdateHealthDataCommand(int HeartRate,
    decimal Temperature,
    decimal Weight,
    int OxygenSaturation);