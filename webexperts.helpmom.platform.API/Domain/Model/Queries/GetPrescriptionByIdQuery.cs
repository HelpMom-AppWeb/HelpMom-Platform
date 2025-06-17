namespace webexperts.helpmom.platform.API.Domain.Model.Queries;

public class GetPrescriptionByIdQuery
{
    public int PrescriptionId { get; }

    public GetPrescriptionByIdQuery(int prescriptionId)
    {
        PrescriptionId = prescriptionId;
    }
}