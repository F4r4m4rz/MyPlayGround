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
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            var y = container.Get<IInjectedClass>();
            var x = new GetInjectedClass();

            Console.ReadLine();
        }
    }
}
