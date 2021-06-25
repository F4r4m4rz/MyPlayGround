using ConsoleApp.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class HostedService : IHostedService
    {
        private readonly ILogger<HostedService> _logger;
        private readonly IServiceProvider _provider;
        private readonly AssemblyLoader _loader;

        public IEnumerable<IConsoleAppAddin> Addins => _loader?.GetAddinInstances();

        public HostedService(ILogger<HostedService> logger, IServiceProvider provider, AssemblyLoader loader)
        {
            _logger = logger;
            _provider = provider;
            _loader = loader;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            foreach (var item in Addins)
            {
                item.Start(_provider);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
