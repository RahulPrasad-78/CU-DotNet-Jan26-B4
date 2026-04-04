namespace Assessment13.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (IOException ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var result = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message
                };

                await context.Response.WriteAsJsonAsync(result);
            }
            catch (InvalidRatingException ex)
            {
                context.Response.StatusCode = 400;

                await context.Response.WriteAsJsonAsync(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
    }

    [Serializable]
    internal class InvalidRatingException : System.Exception
    {
        public InvalidRatingException()
        {
        }

        public InvalidRatingException(string? message) : base(message)
        {
        }

        public InvalidRatingException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}