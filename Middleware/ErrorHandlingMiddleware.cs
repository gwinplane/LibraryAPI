using System.Net;
using System.Text.Json;

namespace LibraryAPI.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var message = "Произошла внутренняя ошибка сервера";

            if (ex is KeyNotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
                message = ex.Message;
            }
            else if (ex is ArgumentException)
            {
                statusCode = HttpStatusCode.BadRequest;
                message = ex.Message;
            }

            var result = JsonSerializer.Serialize(new
            {
                error = message,
                statusCode = (int)statusCode
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(result);
        }
    }
}