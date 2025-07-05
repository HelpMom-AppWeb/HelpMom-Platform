namespace webexperts.helpmom.platform.API.HealthMonitoring.Interfaces.REST.Resources;

public record CreateHealthDataResource(int HeartRate, decimal Temperature, decimal Weight, int OxygenSaturation, int PatientId);