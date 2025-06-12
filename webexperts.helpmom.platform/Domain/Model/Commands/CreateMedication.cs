
namespace webexperts.helpmom.platform.Domain.Model.Commands;

public record CreateMedicationCommand(
    string Name,
    string Concentration,
    decimal QuantityAmount,
    string QuantityUnit,
    string Dose,
    string Via,
    int FrequencyTimesPerDay,
    string FrequencySchedule,
    int DurationValue,
    string DurationUnit,
    int PrescriptionId
);