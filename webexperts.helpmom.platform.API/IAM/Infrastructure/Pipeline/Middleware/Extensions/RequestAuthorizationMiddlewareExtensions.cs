using webexperts.helpmom.platform.API.IAM.Infrastructure.Pipeline.Middleware.Components;

namespace webexperts.helpmom.platform.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;

public static class RequestAuthorizationMiddlewareExtensions
{
 
    public static IApplicationBuilder UseRequestAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestAuthorizationMiddleware>();
    }
}