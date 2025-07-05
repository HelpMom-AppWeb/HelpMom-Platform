using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using webexperts.helpmom.platform.API.IAM.Domain.Model.Aggregates;

namespace webexperts.helpmom.platform.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter

{

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Verify if the endpoint has AllowAnonymous attribute
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        // If the endpoint has AllowAnonymous attribute, skip authorization
        if (allowAnonymous)
        {
            Console.WriteLine("Skipping authorization");
            return;
        }
        // Verify if the user is authenticated
        var user = (User?)context.HttpContext.Items["User"];
        // If the user is not authenticated, return 401 Unauthorized
        if (user is null) context.Result = new UnauthorizedResult();
    }
}