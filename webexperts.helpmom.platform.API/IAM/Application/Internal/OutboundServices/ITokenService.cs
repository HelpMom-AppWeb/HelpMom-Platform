using webexperts.helpmom.platform.API.IAM.Domain.Model.Aggregates;

namespace webexperts.helpmom.platform.API.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
  
    string GenerateToken(User user);
    
   
    Task<int?> ValidateToken(string token);
}