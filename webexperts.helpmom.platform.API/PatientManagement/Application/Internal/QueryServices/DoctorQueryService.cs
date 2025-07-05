using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Queries;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Repositories;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Services;

namespace webexperts.helpmom.platform.API.PatientManagement.Application.Internal.QueryServices;

public class DoctorQueryService(IDoctorRepository doctorRepository) : IDoctorQueryService
{
    public async Task<Doctor?> Handle(GetDoctorByIdQuery query)
    {
        return await doctorRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Doctor>> Handle(GetAllDoctorsQuery query)
    {
        return await doctorRepository.ListAsync();
    } 
    
}