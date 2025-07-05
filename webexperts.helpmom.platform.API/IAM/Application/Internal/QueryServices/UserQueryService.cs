using webexperts.helpmom.platform.API.IAM.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.IAM.Domain.Model.Queries;
using webexperts.helpmom.platform.API.IAM.Domain.Repositories;
using webexperts.helpmom.platform.API.IAM.Domain.Services;

namespace webexperts.helpmom.platform.API.IAM.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    // inheritDoc
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.UserId);
    }

    // inheritDoc
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    // inheritDoc
    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindByUsernameAsync(query.Username);
    }
}