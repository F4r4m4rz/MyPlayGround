using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestComponentModelIoC
{
    public class GetInjectedClass
    {
        [Import]
        public IInjectedClass Injected { get; set; }
    }
}
