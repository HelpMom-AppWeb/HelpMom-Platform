namespace webexperts.helpmom.platform.API.Domain.Model.Aggregate;

public class Treatment
{
    public int Id { get; private set; }
    public int PatientId { get; private set; }
    public string TreatmentName { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public bool IsActive { get; private set; }

    private readonly List<Treatment> _prescriptions;
    public IReadOnlyCollection<Treatment> Prescriptions => _prescriptions.AsReadOnly();

    public Treatment()
    {
        TreatmentName = string.Empty;
        Description = string.Empty;
        IsActive = true;
        _prescriptions = new List<Treatment>();
        StartDate = DateTime.UtcNow;
    }

    public Treatment(int patientId, string treatmentName, string description)
    {
        PatientId = patientId;
        TreatmentName = treatmentName;
        Description = description;
        IsActive = true;
        StartDate = DateTime.UtcNow;
        _prescriptions = new List<Treatment>();
    }

    public void AddPrescription(Treatment prescription)
    {
        _prescriptions.Add(prescription);
    }

    public void CompleteTreatment()
    {
        IsActive = false;
        EndDate = DateTime.UtcNow;
    }

    public void UpdateTreatment(string treatmentName, string description)
    {
        TreatmentName = treatmentName;
        Description = description;
    }
}