using RobertMaxim.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim.Domain
{
    public interface IDepotInventoryService
    {
        void AssociateDrugs(string depotId, int startPickNumber, int endPickNumber);
        void DisassociateDrugs(int startPickNumber, int endPickNumber);
    }
}
