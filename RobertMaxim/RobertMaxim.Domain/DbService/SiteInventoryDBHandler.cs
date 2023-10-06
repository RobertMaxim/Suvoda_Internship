using RobertMaxim.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim.Domain.DbService
{
    class SiteInventoryDBHandler : ISiteInventoryDBHandler
    {
        protected readonly AppDbContext _appDbContext;
        public SiteInventoryDBHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async void UpdateSiteInventory(string destinationSiteId, string requestedDrugCode, int requestedQuantity)
        {
            Site needingSite = _appDbContext.Sites.First(s => s.Id.Equals(destinationSiteId));
            Country country = _appDbContext.Countries.First(c => c.Id.Equals(needingSite.CountryCode));

            IEnumerable<DrugUnit> requestedDrugs = country.Supplier.DrugUnits.Where(du => du.Type.Name.Equals(requestedDrugCode))
                                                                             .Take(requestedQuantity);

            needingSite.DrugUnits = needingSite.DrugUnits.Concat(requestedDrugs)
                                                         .ToList();

            country.Supplier.DrugUnits = country.Supplier.DrugUnits.Where(du => !requestedDrugs.Contains(du))
                                                                   .ToList();
            await _appDbContext.SaveChangesAsync();
        }
    }
}
