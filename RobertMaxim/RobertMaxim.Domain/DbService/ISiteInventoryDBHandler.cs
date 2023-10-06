using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim.Domain.DbService
{
    interface ISiteInventoryDBHandler
    {
        void UpdateSiteInventory(string destinationSiteId, string requestedDrugCode, int requestedQuantity);
    }
}
