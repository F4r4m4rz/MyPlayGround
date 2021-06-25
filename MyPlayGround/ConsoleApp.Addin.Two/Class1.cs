using ConsoleApp.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp.Addin.Two
{
    public class Class1 : IConsoleAppAddin
    {
        public void AddServices(IServiceCollection services)
        {
            services.AddSingleton<MyClass>();
        }

        public void Start(IServiceProvider provider)
        {
            var myClass = provider.GetRequiredService<MyClass>();
        }
    }
}
