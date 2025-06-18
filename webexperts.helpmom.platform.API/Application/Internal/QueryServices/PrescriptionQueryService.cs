using webexperts.helpmom.platform.API.Domain.Model.Aggregate;
using webexperts.helpmom.platform.API.Domain.Model.Queries;
using webexperts.helpmom.platform.API.Domain.Services;

namespace webexperts.helpmom.platform.API.Application.Internal.QueryServices
{
    public class PrescriptionQueryService : IPrescriptionQueryService
    {
        private IPrescriptionQueryService _prescriptionQueryServiceImplementation;
     
        public Task<Prescription?> Handle(GetPrescriptionByIdQuery query)
        {
            return _prescriptionQueryServiceImplementation.Handle(query);
        }
    }
}