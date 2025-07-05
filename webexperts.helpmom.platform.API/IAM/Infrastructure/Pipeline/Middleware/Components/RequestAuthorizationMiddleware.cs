using webexperts.helpmom.platform.API.IAM.Application.Internal.OutboundServices;
using webexperts.helpmom.platform.API.IAM.Domain.Model.Queries;
using webexperts.helpmom.platform.API.IAM.Domain.Services;
using webexperts.helpmom.platform.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace webexperts.helpmom.platform.API.IAM.Infrastructure.Pipeline.Middleware.Components;

public class RequestAuthorizationMiddleware(RequestDelegate next)
{

    public async Task InvokeAsync(
        HttpContext context,
        IUserQueryService userQueryService,
        ITokenService tokenService)
    {
        Console.WriteLine("Entering InvokeAsync");
        var allowAnonymous = context.Request.HttpContext.GetEndpoint()!
            .Metadata
            .Any(m => m.GetType() == typeof(AllowAnonymousAttribute));
        Console.WriteLine($"AllowAnonymous: {allowAnonymous}");
        if (allowAnonymous)
        {
            Console.WriteLine("Skipping authorization");
            await next(context);
            return;
        }
        Console.WriteLine("Entering authorization");
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token is null) throw new Exception("Null of invalid token");
        
        var userId = await tokenService.ValidateToken(token);
        
        if (userId is null) throw new Exception("Invalid token");
        
        var getUserByIdQuery = new GetUserByIdQuery(userId.Value);

        var user = await userQueryService.Handle(getUserByIdQuery);
        Console.WriteLine("Successfully authorized. Updating context...");
        context.Items["User"] = user;
        Console.WriteLine("Continuing to next middleware in pipeline");
        await next(context);
    }
}