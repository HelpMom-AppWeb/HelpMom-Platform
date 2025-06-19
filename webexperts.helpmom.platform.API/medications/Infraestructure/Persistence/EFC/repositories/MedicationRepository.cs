using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.API.Domain.Model.Entities;
using webexperts.helpmom.platform.API.Domain.Repositories;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace webexperts.helpmom.platform.API.Infraestructure.Persistence.EFC.repositories;

public class MedicationRepository : BaseRepository<Medication>, IMedicationRepository
{
    public MedicationRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Medication>> FindByPrescriptionIdAsync(Guid prescriptionId)
    {
        return await Context.Set<Medication>()
            .Where(m => m.PrescriptionId == prescriptionId)
            .ToListAsync();
    }

    public async Task<Medication?> FindByNameAndPrescriptionIdAsync(string name, Guid prescriptionId)
    {
        return await Context.Set<Medication>()
            .FirstOrDefaultAsync(m => m.Name.ToLower() == name.ToLower() && m.PrescriptionId == prescriptionId);
    }

    public Task<bool> ExistsInPrescriptionAsync(Guid PrescriptionId, Guid MedicationId)
    {
        return Context.Set<Medication>()
            .AnyAsync(m => m.Id == MedicationId && m.PrescriptionId == PrescriptionId);
    }

    public async Task<bool> ExistsInPrescriptionAsync(string name, Guid prescriptionId)
    {
        return await Context.Set<Medication>()
            .AnyAsync(m => m.Name.ToLower() == name.ToLower() && m.PrescriptionId == prescriptionId);
    }

    public async Task<Medication?> FindByMedicationIdAsync(Guid medicationId)
    {
        return await Context.Set<Medication>()
            .FirstOrDefaultAsync(m => m.Id == medicationId);
    }
}