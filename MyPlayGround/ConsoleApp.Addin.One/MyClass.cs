using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Addin.One
{
    public class MyClass
    {
        private readonly ILogger<MyClass> _logger;

        public MyClass(ILogger<MyClass> logger)
        {
            _logger = logger;

            _logger.LogInformation("We are in the constructor");
        }
    }
}
