
using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.API.IAM.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.IAM.Domain.Repositories;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace webexperts.helpmom.platform.API.IAM.Infrastructure.Persistence.EFC.Repositories;


public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    // inheritedDoc
    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Username.Equals(username));
    }

    // inheritedDoc
    public bool ExistsByUsername(string username)
    {
        return Context.Set<User>().Any(user => user.Username.Equals(username));
    }
}