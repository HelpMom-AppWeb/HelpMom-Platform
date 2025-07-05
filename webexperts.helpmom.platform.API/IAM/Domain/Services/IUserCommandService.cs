using webexperts.helpmom.platform.API.IAM.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.IAM.Domain.Model.Commands;

namespace webexperts.helpmom.platform.API.IAM.Domain.Services;


public interface IUserCommandService
{
  
    Task Handle(SignUpCommand command);
    
   
    Task<(User user, string token)> Handle(SignInCommand command);
}