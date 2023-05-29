using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using NuGet.Protocol.Core.Types;
using StackExchange.Redis;
using UserAgentParser;

namespace LearnASPNETCoreRazorPagesWithRealApps.Middlewares
{
    public class BrowserMiddleware
    {
        private readonly RequestDelegate _next;

        public BrowserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var userAgent = httpContext.Request.Headers["User-Agent"].FirstOrDefault().ToString();
            //var ipAddress = httpContext.Connection.RemoteIpAddress.ToString();
            //var url = httpContext.Request.Path;
            //Debug.WriteLine("userAgent: " + userAgent);
            //Debug.WriteLine("ipAddress: " + ipAddress);
            //Debug.WriteLine("url: " + url);
            if (userAgent.Contains("Edg"))
            {
                var response = httpContext.Response;
                response.Redirect("https://www.mozilla.org/pl/firefox/new/ ", true);
            }
            return _next(httpContext);
        }
    }

    public static class BrowserMiddlewareExtensions
    {
        public static IApplicationBuilder UseBrowserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BrowserMiddleware>();
        }
    }
}