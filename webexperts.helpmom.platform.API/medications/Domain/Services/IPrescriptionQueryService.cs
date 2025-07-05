using webexperts.helpmom.platform.API.Domain.Model.Aggregate;
using webexperts.helpmom.platform.API.Domain.Model.Queries;

namespace webexperts.helpmom.platform.API.Domain.Services;
    
    public interface IPrescriptionQueryService
    {
        Task<Prescription?> Handle(GetPrescriptionByIdQuery query);
    }