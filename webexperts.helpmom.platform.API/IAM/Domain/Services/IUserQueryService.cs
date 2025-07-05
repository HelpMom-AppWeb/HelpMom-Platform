using webexperts.helpmom.platform.API.IAM.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.IAM.Domain.Model.Queries;

namespace webexperts.helpmom.platform.API.IAM.Domain.Services;


public interface IUserQueryService
{

    Task<User?> Handle(GetUserByIdQuery query);
    

    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    

    Task<User?> Handle(GetUserByUsernameQuery query);
}