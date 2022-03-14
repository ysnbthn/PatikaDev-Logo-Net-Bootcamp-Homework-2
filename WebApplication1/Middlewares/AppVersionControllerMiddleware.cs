using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace WebApplication1.Middlewares
{

    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AppVersionControllerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public AppVersionControllerMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                // Optional: Get version from assembly using reflection
                //Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;

                // Get version from appsettings
                var currentVersion = new Version(_configuration.GetValue<string>("app-version"));
                var requestVersion = new Version(httpContext.Request.Headers["app-version"]);

                if (requestVersion.CompareTo(currentVersion) <= 0 || httpContext.Request.Path == "/login" || httpContext.Request.Path == "/register")
                {
                    await _next(httpContext);
                }
                else
                {
                    httpContext.Response.StatusCode = 401;
                    await httpContext.Response.WriteAsync("Unuthorized");
                }
            }
            catch (Exception ex)
            {
                await HandleExcepitonAsync(httpContext, ex);
            }
        }
        private async Task HandleExcepitonAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync($"Unauthorized: {exception.Message}");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AppVersionControllerMiddlewareExtensions
    {
        public static IApplicationBuilder UseAppVersionControllerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AppVersionControllerMiddleware>();
        }
    }
}
