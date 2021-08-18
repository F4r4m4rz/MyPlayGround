using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestComponentModelIoC
{
    public class Container
    {
        private CompositionContainer _container;

        public Container()
        {
            var clientReg = new RegistrationBuilder();
            clientReg.ForType<InjectedClass>().Export<IInjectedClass>();
            clientReg.ForType<InjectedClass2>().Export<IInjectedClass2>();

            var clientAssemmbly = new AssemblyCatalog(typeof(Container).Assembly, clientReg);

            var catalog = new AggregateCatalog(clientAssemmbly);

            _container = new CompositionContainer(clientAssemmbly, CompositionOptions.DisableSilentRejection | CompositionOptions.IsThreadSafe);
            _container.ComposeParts(this);
        }

        public T Get<T>()
        {
            return _container.GetExportedValue<T>();
        }
    }
}
