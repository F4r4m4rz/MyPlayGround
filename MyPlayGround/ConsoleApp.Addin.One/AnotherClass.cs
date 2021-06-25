using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Addin.One
{
    public class AnotherClass
    {
        public AnotherClass(ILogger<AnotherClass> logger, MyClass myClass)
        {
            logger.LogInformation("We are in constructor for AnotherClass");
        }
    }
}
