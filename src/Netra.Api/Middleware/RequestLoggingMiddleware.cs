using System.Diagnostics;

namespace Netra.Api.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var sw = Stopwatch.StartNew();
        var method = context.Request.Method;
        var path = context.Request.Path;

        await _next(context);

        sw.Stop();
        var status = context.Response.StatusCode;

        _logger.LogInformation("HTTP {Method} {Path} responded {Status} in {Duration}ms",
            method, path, status, sw.ElapsedMilliseconds);
    }
}
