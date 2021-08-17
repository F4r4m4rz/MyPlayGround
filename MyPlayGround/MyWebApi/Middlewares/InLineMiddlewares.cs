using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class InLineMiddlewares
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            //app.Use(async (context, next) =>
            //{
            //    context.Response.Headers[Guid.NewGuid().ToString()] = "Hello";
            //    await next.Invoke();
            //});

            app.Map("/hello", SayHello);
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello, from custom middleware");
            //});

            return app;
        }

        private static void SayHello(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello, from custom middleware");
            });
        }
    }
}
