using ConsoleApp.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp.Addin.One
{
    public class ConsoleAppAddin : IConsoleAppAddin
    {
        public void AddServices(IServiceCollection services)
        {
            services.AddSingleton<MyClass>();
            services.AddSingleton<AnotherClass>();
        }

        public void Start(IServiceProvider provider)
        {
            var anotherClass = provider.GetRequiredService<AnotherClass>();
        }
    }
}
