using webexperts.helpmom.platform.API.Shared.Domain.Repositories;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    /// <inheritdoc />
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}