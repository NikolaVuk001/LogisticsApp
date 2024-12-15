using LogisticsApp.Domain.Exceptions;

namespace LogisticsApp.API.Middlewares;


public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (EntityNotFoundException ex)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync(ex.Message);

            logger.LogWarning(ex.Message);
        }
        catch (EntityAlreadyExistsException ex)
        {
            context.Response.StatusCode = 409;
            await context.Response.WriteAsync(ex.Message);

            logger.LogWarning(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Something went wrong !");

        }
    }
}