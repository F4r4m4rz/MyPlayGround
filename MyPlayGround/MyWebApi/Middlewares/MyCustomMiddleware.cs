using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Middlewares
{
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public MyCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<MyCustomMiddleware> logger)
        {
            logger.LogError("Inside custom middleware");
            var guid = Guid.NewGuid().ToString();
            httpContext.Response.Headers[guid] = "Hello";
            await _next.Invoke(httpContext);
        }
    }
}
