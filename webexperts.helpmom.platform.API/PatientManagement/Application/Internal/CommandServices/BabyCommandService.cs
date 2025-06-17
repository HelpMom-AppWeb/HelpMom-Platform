using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Entities;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Repositories;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Services;
using webexperts.helpmom.platform.API.Shared.Domain.Repositories;

namespace webexperts.helpmom.platform.API.PatientManagement.Application.Internal.CommandServices;

public class BabyCommandService(IBabyRepository babyRepository, IUnitOfWork unitOfWork)
    : IBabyCommandService
{
    public async Task<Baby?> Handle(CreateBabyCommand command)
    {
        var baby = new Baby(command);
        await babyRepository.AddAsync(baby);
        await unitOfWork.CompleteAsync();
        return baby;
    }
}