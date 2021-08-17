using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        public enum TestEnum { a,b,c,d,e,f}
        static void Main(string[] args)
        {
            var test = new[] { new ClassOne { MyProperty = 1 } };
            var cast = test.Select(a => a as ClassTwo);


            var x = TestEnum.a;
            x |= TestEnum.f;
            x |= TestEnum.c;
            Console.WriteLine(x);
            Console.Read();

            // Create host builder
            CreateHost()
                .Build()
                .Start();

            Console.Read();
        }

        static IHostBuilder CreateHost() =>

            Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddJsonFile("AppSettings.json");
                })
                .AddMyApplicationServices();

    }

    public class ClassOne
    {
        public int MyProperty { get; set; }
    }

    public class ClassTwo : ClassOne
    {

    }
}
