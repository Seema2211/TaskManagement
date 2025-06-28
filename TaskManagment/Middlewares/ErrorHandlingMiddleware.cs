using System.Net;
using System.Text.Json;
using TaskManagement.Exceptions;

namespace TaskManagement.Middlewares
{
    /// <summary>
    /// Middleware for handling and formatting API exceptions.
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
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
            catch (EntityOperationException ex)
            {
                _logger.LogWarning(ex, "Entity operation failed.");
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await WriteErrorResponse(context, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception.");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await WriteErrorResponse(context, "An unexpected error occurred.");
            }
        }

        private async Task WriteErrorResponse(HttpContext context, string message)
        {
            context.Response.ContentType = "application/json";
            var errorResponse = JsonSerializer.Serialize(new { error = message });
            await context.Response.WriteAsync(errorResponse);
        }
    }
}
