using Microsoft.AspNetCore.Http;

public class AuthorizationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next
    )
    {
        Console.WriteLine($"Logging {context.HttpContext}");
        var token = context.HttpContext.Request.Headers["token"];
        if (token != String.Empty)
        {
            if (token == "san123")
            {

            }
            else
            {
                return Results.BadRequest("InCorrect Authorization Token");
            }
        }
        return await next(context);
    }
}

