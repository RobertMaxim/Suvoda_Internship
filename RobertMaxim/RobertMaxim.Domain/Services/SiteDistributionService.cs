using RobertMaxim.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim.Domain.Services
{
    public class SiteDistributionService:ISiteDistributionService
    {
        protected readonly SystemDataSet _systemDataSet;
        public SiteDistributionService(SystemDataSet systemDataSet)
        {
            _systemDataSet = systemDataSet;
        }

        public IEnumerable<DrugUnit> GetRequestedDrugUnits(string siteId, string drugCode, int quantity)
        {
            Site needingSite = _systemDataSet.Sites.First(s => s.Id.Equals(siteId));
            Country country = _systemDataSet.Countries.First(c => c.Id.Equals(needingSite.CountryCode));

            IEnumerable<DrugUnit> requestedDrugs = country.Supplier.DrugUnits.Where(du => du.Type.Name.Equals(drugCode))
                                                                         .Take(quantity);
            needingSite.DrugUnits = requestedDrugs.ToList();
            return requestedDrugs;
        } 
    }
}
