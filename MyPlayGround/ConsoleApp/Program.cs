using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create host builder
            CreateHost()
                .Build()
                .Start();
        }

        static IHostBuilder CreateHost() =>

            Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddJsonFile("AppSettings.json");
                })
                .AddMyApplicationServices();

    }
}
