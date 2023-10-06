using RobertMaxim.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim.Domain
{
    public class DepotInventoryService : IDepotInventoryService
    {
        protected readonly AppDbContext _appDbContext;
        public DepotInventoryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async void AssociateDrugs(string depotId, int startPickNumber, int endPickNumber)
        {
            List<DrugUnit> listOfValidDrugs = new List<DrugUnit>();
            Depot depot = _appDbContext.Depots.Where(d => d.Id.Equals(depotId))
                                              .First();

            foreach (DrugUnit drugUnit in _appDbContext.DrugUnits) {
                if (drugUnit.PickNumber > startPickNumber 
                    && drugUnit.PickNumber < endPickNumber
                    && drugUnit.Depot == null) {
                    listOfValidDrugs.Add(drugUnit);
                    drugUnit.Depot = depot;
                }
            }

            depot.DrugUnits = listOfValidDrugs;

            await _appDbContext.SaveChangesAsync();
        }

        public async void DisassociateDrugs(int startPickNumber, int endPickNumber)
        {
            foreach (DrugUnit drugUnit in _appDbContext.DrugUnits) 
            {
                if (drugUnit.PickNumber >= startPickNumber && drugUnit.PickNumber <= endPickNumber) 
                {
                    drugUnit.Depot = null;
                }
            }

            foreach (Depot depot in _appDbContext.Depots) 
            {
                if (depot.DrugUnits != null && depot.DrugUnits.Count > 0) 
                {
                    depot.DrugUnits = depot.DrugUnits.Where(du => du.PickNumber <= startPickNumber
                                                               || du.PickNumber >= endPickNumber)
                                                     .ToArray();
                }
            }

            await _appDbContext.SaveChangesAsync();
        }
    }
}

//public void AssociateDrugs(ref List<DrugUnit> drugUnits, List<Depot> depots, string depotId, int startPickNumber, int endPickNumber)
//{
//    List<DrugUnit> listOfValidDrugs = new List<DrugUnit>();
//    Depot depot = depots.Where(d => d.Id == depotId).First();

//    foreach (DrugUnit drugUnit in drugUnits) {
//        if (drugUnit.PickNumber > startPickNumber
//            && drugUnit.PickNumber < endPickNumber
//            && drugUnit.Depot == null) {
//            listOfValidDrugs.Add(drugUnit);
//            drugUnit.Depot = depot;
//        }
//    }

//    depot.DrugUnits = listOfValidDrugs;
//}

//public void DisassociateDrugs(ref List<DrugUnit> drugUnits, List<Depot> depots, int startPickNumber, int endPickNumber)
//{
//    foreach (DrugUnit drugUnit in drugUnits) {
//        if (drugUnit.PickNumber >= startPickNumber
//            && drugUnit.PickNumber <= endPickNumber) {
//            drugUnit.Depot = null;
//        }
//    }

//    foreach (Depot depot in depots) {
//        if (depot.DrugUnits != null && depot.DrugUnits.Count > 0) {
//            depot.DrugUnits = depot.DrugUnits.Where(du => du.PickNumber <= startPickNumber
//                                               || du.PickNumber >= endPickNumber)
//                                     .ToArray();
//        }
//    }
//}