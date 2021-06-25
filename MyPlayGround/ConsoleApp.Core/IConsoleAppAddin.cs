using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Core
{
    public interface IConsoleAppAddin
    {
        public void AddServices(IServiceCollection services);

        public void Start(IServiceProvider provider);
    }
}
