using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Commands;

namespace webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Aggregates;

public partial class HealthData
{
    public HealthData(int heartRate, decimal temperature, decimal weight, int oxygenSaturation, int patientId)
    {
        HeartRate = heartRate;
        Temperature = temperature;
        Weight = weight;
        OxygenSaturation = oxygenSaturation;
        PatientId = patientId;
    }

    public int Id { get; }
    public int HeartRate { get; private set; }
    public decimal Temperature { get; private set; }
    public decimal Weight { get; private set; }
    public int OxygenSaturation { get; private set; }
    public int PatientId { get; private set; }

    public HealthData(CreateHealthDataCommand command)
    {
        HeartRate = command.HeartRate;
        Temperature = command.Temperature;
        Weight = command.Weight;
        OxygenSaturation = command.OxygenSaturation;
        PatientId = command.PatientId;
    }
    
    

}