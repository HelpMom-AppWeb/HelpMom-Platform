namespace webexperts.helpmom.platform.API.Domain.Model.Queries;

public class GetPrescriptionByIdQuery
{
    public Guid PrescriptionId { get; }

    public GetPrescriptionByIdQuery(Guid prescriptionId)
    {
        PrescriptionId = prescriptionId;
    }
}