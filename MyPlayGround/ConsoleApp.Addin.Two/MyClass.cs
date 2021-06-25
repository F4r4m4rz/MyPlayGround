using ConsoleApp.Addin.One;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Addin.Two
{
    public class MyClass
    {
        public MyClass(ILogger<MyClass> logger, AnotherClass anotherClass)
        {
            logger.LogInformation("We are in another assembly and getting anotherClass");
        }
    }
}
