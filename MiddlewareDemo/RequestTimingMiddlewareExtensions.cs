using Microsoft.AspNetCore.Builder;

namespace MiddlewareDemo.Middleware;

public static class RequestTimingMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestLoggingMiddleware>();
    }
}
