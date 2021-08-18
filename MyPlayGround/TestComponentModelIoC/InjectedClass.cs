using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestComponentModelIoC
{
    public interface IInjectedClass
    {
        string MyText { get; set; }
    }

    public class InjectedClass : IInjectedClass
    {
        public string MyText { get; set; } = "Hello";

        [Import]
        public IInjectedClass2 InjectedClass2 { get; set; }
    }

    public interface IInjectedClass2
    {
        string MyText { get; set; }
    }

    public class InjectedClass2 : IInjectedClass2
    {
        public string MyText { get; set; } = "Bye";
    }
}
