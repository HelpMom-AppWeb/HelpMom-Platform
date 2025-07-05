using webexperts.helpmom.platform.API.IAM.Domain.Model.Commands;
using webexperts.helpmom.platform.API.IAM.Domain.Model.Queries;
using webexperts.helpmom.platform.API.IAM.Domain.Services;
using webexperts.helpmom.platform.API.IAM.Interfaces.ACL;

namespace webexperts.helpmom.platform.API.IAM.Application.ACL.Services;

public class IamContextFacade(
    IUserCommandService userCommandService,
    IUserQueryService userQueryService) : IIamContextFacade
{
    // <inheritdoc />
    public async Task<int> CreateUser(string username, string password)
    {
        var signUpCommand = new SignUpCommand(username, password);
        await userCommandService.Handle(signUpCommand);
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.Id ?? 0;
    }

    // <inheritdoc />
    public async Task<int> FetchUserIdByUsername(string username)
    {
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.Id ?? 0;
    }

    // <inheritdoc />
    public async Task<string> FetchUsernameByUserId(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var result = await userQueryService.Handle(getUserByIdQuery);
        return result?.Username ?? string.Empty;
    }
}