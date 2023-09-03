using System.Net;
using System.Text.Json;
using MagniFinance.Infrastructure.ExceptionHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MagniFinance.Infrastructure.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly ILogger<ErrorHandlerMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            _logger.LogError($"<====================== ERROR OCCURED ======================>");
            _logger.LogError("Error Occured while processing your request");
            _logger.LogError(error.Message);
            _logger.LogError(error.StackTrace);
            _logger.LogError($"<====================== ERROR OCCURED ======================>");
            
            var response = context.Response;
            response.ContentType = "application/json";

            var respCode = "XXX";
            var respMessage = "Unknown status";
            var respDescription = "";
            object errors;

            switch (error)
            {
                case ValidationException<object> e:
                    response.StatusCode = (int)e.StatusCode;
                    respCode = e.ResponseCode;
                    respMessage = e.ResponseMessage;
                    respDescription = e.ResponseDescription;
                    errors = e.Errors;
                    break;

                case AppException<object> e:
                    response.StatusCode = (int)e.StatusCode;
                    respCode = e.ResponseCode;
                    respMessage = e.ResponseMessage;
                    respDescription = e.ResponseDescription;
                    errors = e.Errors;
                    break;

                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    respCode = "X500";
                    respMessage = "Internal Server Error";
                    respDescription = error.Message;
                    errors = "Error occurred while processing your request";
                    break;
            }

            var result = JsonSerializer.Serialize(new
            {
                respCode,
                respMessage,
                respDescription,
                errors
            });
            await response.WriteAsync(result);
        }
    }
}