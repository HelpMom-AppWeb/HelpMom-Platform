using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Repositories;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace webexperts.helpmom.platform.API.PatientManagement.Infrastructure.Persistence.EFC.Repositories;

public class DoctorRepository(AppDbContext context) : BaseRepository<Doctor>(context), IDoctorRepository
{

}