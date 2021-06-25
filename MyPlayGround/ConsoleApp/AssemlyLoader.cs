using ConsoleApp.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class AssemblyLoader
    {
        private readonly string _path;
        private readonly ILogger<AssemblyLoader> _logger;
        private readonly ICollection<Action<IServiceCollection>> _actions;
        private readonly ICollection<IConsoleAppAddin> _instances;

        public AssemblyLoader(string path, ILogger<AssemblyLoader> logger)
        {
            _path = path;
            _logger = logger;
            _actions = new List<Action<IServiceCollection>>();
            _instances = new List<IConsoleAppAddin>();
        }

        public IEnumerable<IConsoleAppAddin> GetAddinInstances() => _instances;

        public void Load(IServiceCollection services)
        {
            var assemblyFiles = Directory.GetFiles(_path, "ConsoleApp.Addin.*.dll", SearchOption.TopDirectoryOnly);
            Load(assemblyFiles);

            RunActions(services);
        }

        private void RunActions(IServiceCollection services)
        {
            foreach (var action in _actions)
            {
                action.Invoke(services);
            }
        }

        private void Load(IEnumerable<string> assemblyFiles)
        {
            foreach (var assemblyFile in assemblyFiles)
            {
                var raw = File.ReadAllBytes(assemblyFile);
                var assembly = Assembly.Load(raw);
                Load(assembly);
            }
        }

        private void Load(Assembly assembly)
        {
            var addins = assembly.GetTypes()
                                 .Where(type => type.GetInterface(nameof(IConsoleAppAddin)) != null);

            AddAddins(addins);
        }

        private void AddAddins(IEnumerable<Type> addins)
        {
            foreach (var addin in addins)
            {
                AddAddin(addin);
            }
        }

        private void AddAddin(Type addin)
        {
            var instance = Activator.CreateInstance(addin) as IConsoleAppAddin;
            _actions.Add((instance).AddServices);
            _instances.Add(instance);
        }
    }
}
