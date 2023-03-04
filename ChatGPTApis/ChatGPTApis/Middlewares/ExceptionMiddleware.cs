using System.Diagnostics;
using System.Net;
using ChatGPTApis.Contracts;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace ChatGPTApis.Middlewares;

public class ExceptionMiddleware 
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            _logger.LogInformation("Exception from custom logger");
            httpContext.Response.ContentType = "application/json";
            var customError = new Error()
            {
                Message = "Exception thrown from Middleware =>" + e.Message,
                StatusCode = HttpStatusCode.BadRequest
            };
            httpContext.Response.StatusCode = (int)customError.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(customError);
        }
    }
}