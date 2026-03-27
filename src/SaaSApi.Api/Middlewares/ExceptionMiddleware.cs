using System.Text.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var (statusCode, descriptiuon) = ex switch 
            {
                ArgumentException e     => (400, e.Message),
                KeyNotFoundException e  => (404, e.Message),
                IOException e           => (503, "Service temporarily unavailable"),
                _                       => (500, "An unexpected error ocurred")
            };

            var errorResponse = new ErrorResponse
            {
                Status = statusCode,
                Description = descriptiuon,
                TimeStamp = DateTime.UtcNow
            };

            var options = new JsonSerializerOptions 
            { 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
            };

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse, options));
        }
    }
}