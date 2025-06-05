
namespace webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Commands;

public record CreateHealthDataCommand(
    int HeartRate,
    decimal Temperature,
    decimal Weight,
    int OxygenSaturation,
    int PatientId);
