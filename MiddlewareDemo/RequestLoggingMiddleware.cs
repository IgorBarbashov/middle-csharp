using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

        // добавляем обработчик на хук - начало формирования ответа
        context.Response.OnStarting(() =>
        {
            context.Response.Headers.Add("X-Custom-Header", "MyApp");
            return Task.CompletedTask;
        });

        await _next(context);

        // мы не можем добавить заголовок после вызова _next(context), так как Response уже начал формироваться
        // в middleware, который выполняется после RequestLoggingMiddleware или в контроллере
        // после этого он становится read-only и любые попытки изменить его вызовут исключение InvalidOperationException
        // context.Response.Headers.Add("X-Custom-Header", "MyApp");

        Console.WriteLine($"Response: {context.Response.StatusCode}");
    }
}