using DNVS.NPS.DM.ServiceFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDMClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IDMServerToServerService service = new DMServerToServerService();
            var test = service.FindTechdoc(new DNVS.NPS.DM.ServiceFacade.FindModels.TechdocFindModel() { FolderName = "D34893" });
        }
    }
}
