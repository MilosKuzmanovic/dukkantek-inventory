namespace Dukkantek.Inventory.API.Middleware;

using Dukkantek.Inventory.Model.Error;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            switch (error)
            {
                case CustomException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            _logger.LogError($"Error: {error.Message}");

            var result = JsonSerializer.Serialize(new
            {
                type = Enum.GetName(typeof(HttpStatusCode), response.StatusCode),
                status = response.StatusCode,
                message = error.Message,
                stackTrace = error.StackTrace
            });

            await response.WriteAsync(result);
        }
    }
}