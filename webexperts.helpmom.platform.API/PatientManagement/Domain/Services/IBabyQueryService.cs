using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Entities;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Queries;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Services;

public interface IBabyQueryService
{
    Task<Baby?> Handle(GetBabyByIdQuery query);
    Task<Baby?> Handle(GetBabyByMotherIdQuery query);
}