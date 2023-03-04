using System.Net;
using ChatGPTApis.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChatGPTApis.Filters;

public class GlobalExceptionHandeler : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var error = new Error()
        {
            StatusCode = (HttpStatusCode)context.HttpContext.Response.StatusCode,
            Message = context.Exception.Message
        };
        Console.WriteLine($"status code {error.StatusCode} and Message {error.Message}");
        context.Result = new JsonResult(new Error()
        {
            StatusCode = HttpStatusCode.BadRequest, Message = context.Exception.Message
        });
        context.HttpContext.Response.ContentType = "application/json";
    }
}