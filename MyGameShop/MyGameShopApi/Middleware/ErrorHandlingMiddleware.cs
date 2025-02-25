using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MyGameShopApi.Exceptions;
using System;
using System.Threading.Tasks;

namespace MyGameShopApi.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            this.logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync("Something went wrong");
            }
        }
    }
}
