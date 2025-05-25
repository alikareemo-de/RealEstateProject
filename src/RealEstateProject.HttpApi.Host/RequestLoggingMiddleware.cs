using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RealEstateProject.Middleware;

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
        var stopwatch = Stopwatch.StartNew();
        var request = context.Request;

        _logger.LogInformation("Incoming Request: {method} {path} | Query: {query}",
            request.Method,
            request.Path,
            request.QueryString);

        await _next(context);

        stopwatch.Stop();
        var response = context.Response;

        _logger.LogInformation("Response Status Code: {statusCode} in {duration}ms",
            response.StatusCode,
            stopwatch.ElapsedMilliseconds);
    }
}
