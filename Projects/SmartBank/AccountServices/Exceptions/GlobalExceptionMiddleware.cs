using System.Net;
using System.Text.Json;
using AccountServices.Exceptions;

namespace AccountServices.Exceptions
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
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
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            HttpStatusCode status;

            switch (ex)
            {
                case NotFoundException:
                    status = HttpStatusCode.NotFound;
                    break;

                case BadRequestException:
                    status = HttpStatusCode.BadRequest;
                    break;

                default:
                    status = HttpStatusCode.InternalServerError;
                    break;
            }

            var response = new
            {
                statusCode = (int)status,
                message = ex.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}