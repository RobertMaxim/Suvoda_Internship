using RobertMaxim.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim
{
    class DepotHandler
    {
        public static void AssociateDrugs(string depotId, int startPickNumber, int endPickNumber)
        {
            List<DrugUnit> listOfValidDrugs = new List<DrugUnit>();
            foreach (DrugUnit drugUnit in Program.DataSet.DrugUnits)
            {
                if (drugUnit.PickNumber > startPickNumber 
                    && drugUnit.PickNumber < endPickNumber)
                {
                    listOfValidDrugs.Add(drugUnit);
                }
            }

            Depot depot = Program.DataSet.Depots.Where(d => d.Id == depotId).First();

            depot.DrugUnits = listOfValidDrugs;
        }

        public static void DisassociateDrugs(int startPickNumber, int endPickNumber)
        {
            foreach (Depot depot in Program.DataSet.Depots)
            {
                if (depot.DrugUnits != null && depot.DrugUnits.Count > 0)
                {
                    depot.DrugUnits = depot.DrugUnits.Where(du => du.PickNumber < startPickNumber
                                                       || du.PickNumber > endPickNumber)
                                             .ToArray();
                }
            }
        }
    }
}
