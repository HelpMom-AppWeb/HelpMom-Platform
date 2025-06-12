namespace webexperts.helpmom.platform.Domain.Model.Entities;

public class Medication
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Concentration { get; private set; }
    public Quantity Quantity { get; private set; }
    public string Dose { get; private set; }
    public string Via { get; private set; }
    public Frequency Frequency { get; private set; }
    public Duration Duration { get; private set; }
    public int PrescriptionId { get; private set; }

    public Medication()
    {
        Name = string.Empty;
        Concentration = string.Empty;
        Quantity = new Quantity();
        Dose = string.Empty;
        Via = string.Empty;
        Frequency = new Frequency();
        Duration = new Duration();
    }

    public Medication(string name, string concentration, Quantity quantity, 
        string dose, string via, Frequency frequency, Duration duration, 
        int prescriptionId)
    {
        Name = name;
        Concentration = concentration;
        Quantity = quantity;
        Dose = dose;
        Via = via;
        Frequency = frequency;
        Duration = duration;
        PrescriptionId = prescriptionId;
    }

    public void UpdateMedication(string name, string concentration, Quantity quantity,
        string dose, string via, Frequency frequency, Duration duration)
    {
        Name = name;
        Concentration = concentration;
        Quantity = quantity;
        Dose = dose;
        Via = via;
        Frequency = frequency;
        Duration = duration;
    }
}