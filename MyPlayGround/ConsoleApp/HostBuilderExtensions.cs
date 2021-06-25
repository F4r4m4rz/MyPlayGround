using ConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    internal static class HostBuilderExtensions
    {
        internal static IHostBuilder AddMyApplicationServices(this IHostBuilder builder)
        {
            // Add services
            builder.ConfigureServices(ConfigureServices);

            return builder;
        }

        internal static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            // Find assemblies to be added
            var loader = new AssemblyLoader(AppDomain.CurrentDomain.BaseDirectory, null);
            loader.Load(services);
            services.AddSingleton<AssemblyLoader>(loader);

            services.AddHostedService<HostedService>();
        }
    }
}
