
public class MockMiddleware
{
    private readonly RequestDelegate _next;

    public MockMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        context.Items["Scenario"] =
            context.Request.Headers["X-Mock-Scenario"].FirstOrDefault();

        await _next(context);
    }
}