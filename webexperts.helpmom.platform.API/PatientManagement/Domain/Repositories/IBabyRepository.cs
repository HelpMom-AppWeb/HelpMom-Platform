using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Entities;
using webexperts.helpmom.platform.API.Shared.Domain.Repositories;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Repositories;

public interface IBabyRepository : IBaseRepository<Baby>
{
    Task<Baby?> FindBabyByMotherIdAsync(int motherId);
    Task<bool> ExistsByIdAsync(int id);
}