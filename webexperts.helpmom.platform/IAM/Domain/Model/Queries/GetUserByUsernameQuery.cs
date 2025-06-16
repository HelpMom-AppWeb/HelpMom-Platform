using webexperts.helpmom.platform.IAM.Domain.Model.Repository;
using webexperts.helpmom.platform.Shared.Domain.Repositories;
namespace webexperts.helpmom.platform.IAM.Domain.Model.Queries;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}