using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace MassTransit.Infrastructure.Middlewares
{
    internal class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

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
            catch (Exception ex)
            {
                var respose = context.Response;

                var errorId = Guid.NewGuid();

                respose.StatusCode = (int)HttpStatusCode.InternalServerError;

                var result = JsonSerializer.Serialize(new { Id = errorId, ex.Message, respose.StatusCode });

                _logger.LogError($"A Custom Exception Occured. ID: {errorId} - Message: {ex.Message}");

                await respose.WriteAsync(result);
            }
        }
    }
}
