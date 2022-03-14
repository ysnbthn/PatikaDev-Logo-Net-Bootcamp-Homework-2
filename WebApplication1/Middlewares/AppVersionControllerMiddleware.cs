using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;
using System.Threading.Tasks;
using WebApplication1.Helper;

namespace WebApplication1.Middlewares
{
    
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AppVersionControllerMiddleware
    {
        private readonly RequestDelegate _next;

        public AppVersionControllerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IConfiguration config)
        {
            try
            {
                // Optional: Get version from assembly using reflection
                //Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;

                // Get version from appsettings
                var currentVersion = new Version(config.GetValue<string>("AppVersion"));

                if (httpContext.Request.Headers.TryGetValue("app-version", out var version)
                        && Version.TryParse(version, out var requestVersion)
                        && requestVersion.CompareTo(currentVersion) <= 0
                        || httpContext.Request.Path == "/login" || httpContext.Request.Path == "/register"
                )
                {
                    await _next(httpContext);
                }
                else
                {
                    throw new Exception("Enter correct app version");
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
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AppVersionControllerMiddleware>();
        }
    }
}
