using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Entities;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Repositories;
using webexperts.helpmom.platform.API.Shared.Domain.Repositories;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace webexperts.helpmom.platform.API.PatientManagement.Infrastructure.Persistence.EFC.Repositories;

public class BabyRepository(AppDbContext context) : BaseRepository<Baby>(context), IBabyRepository
{
    public async Task<Baby?> FindBabyByMotherIdAsync(int motherId)
    {
        return await Context.Set<Baby>()
            .FirstOrDefaultAsync(p => p.MotherId == motherId);
    }

    public async Task<bool> ExistsByIdAsync(int id)
    {
        return await Context.Set<Baby>().AnyAsync(baby => baby.MotherId == id);
    }
}