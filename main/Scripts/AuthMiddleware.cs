public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Authorization token is missing.");
            return;
        }

        var token = context.Request.Headers["Authorization"];
        if (!IsValidToken(token))
        {
            context.Response.StatusCode = 403; // Forbidden
            await context.Response.WriteAsync("Invalid token.");
            return;
        }

        await _next(context);
    }

    private bool IsValidToken(string token)
    {
        return token == "VALID_TOKEN"; // Приклад
    }
}


