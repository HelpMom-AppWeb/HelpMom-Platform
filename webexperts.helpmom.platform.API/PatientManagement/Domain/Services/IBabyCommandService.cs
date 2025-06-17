using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Entities;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Services;

public interface IBabyCommandService
{
    public Task<Baby?> Handle(CreateBabyCommand command);
}