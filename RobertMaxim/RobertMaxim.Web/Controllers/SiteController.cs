using Microsoft.EntityFrameworkCore;
using RobertMaxim.DataModel;
using RobertMaxim.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RobertMaxim.Web.Controllers
{
    [Route("[controller]")]
    public class SiteController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public SiteController()
        {
            _appDbContext = new AppDbContext();
        }

        [HttpGet]
        public ActionResult GetSites()
        {
            List<SiteViewModel> sites = _appDbContext.Sites.Select(site => new SiteViewModel()
            {
                Site= site,
                CountryName = _appDbContext.Countries.First(c => c.Id == site.CountryCode).Name
            }).ToList();

            return View("Sites", sites);
        }

        public ActionResult RequestIndex(Site site)
        {
            List<DrugType> countriesAvailableDrugs = _appDbContext.Countries.Include(c => c.Supplier)
                                                                            .ThenInclude(s => s.DrugUnits)
                                                                            .ThenInclude(du => du.Type)
                                                                            .First(c => c.Id == site.CountryCode)
                                                                            .Supplier.DrugUnits
                                                                            .Select(t => t.Type)
                                                                            .Distinct()
                                                                            .ToList();

            RequestDrugViewModel requestDrugViewModel = new RequestDrugViewModel() { Site = site, DrugTypes = countriesAvailableDrugs };
            return View("DrugRequest", requestDrugViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> GetRequestedDrugUnits(string siteId, string drugCode, int quantity)
        {
            Site needingSite = _appDbContext.Sites.First(s => s.Id.Equals(siteId));
            Country country = _appDbContext.Countries.Include(c => c.Supplier)
                                                     .ThenInclude(s => s.DrugUnits)
                                                     .ThenInclude(t => t.Type)
                                                     .First(c => c.Id.Equals(needingSite.CountryCode));

            List<DrugUnit> requestedDrugs = country.Supplier.DrugUnits?.Where(du => du.Type.Name.Equals(drugCode))
                                                                         .Take(quantity).ToList() ?? null;

            if (requestedDrugs == null)
            {
                ModelState.AddModelError("", "Couldn't request this type of drugs as it isn't assigned to the site's depot");
            }

            needingSite.DrugUnits = needingSite.DrugUnits?.Concat(requestedDrugs)
                                                          .Distinct()
                                                          .ToList() ?? requestedDrugs;

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("GetSites");
        }

        [HttpPost]
        public async Task<ActionResult> UpdateSiteInventory(string destinationSiteId, string requestedDrugCode, int requestedQuantity)
        {
            //to move the functionality to services and keep here essentials
            Site needingSite = _appDbContext.Sites.First(s => s.Id.Equals(destinationSiteId));
            Country country = _appDbContext.Countries.First(c => c.Id.Equals(needingSite.CountryCode));

            IEnumerable<DrugUnit> requestedDrugs = country.Supplier.DrugUnits.Where(du => du.Type.Name.Equals(requestedDrugCode))
                                                                             .Take(requestedQuantity);

            needingSite.DrugUnits = needingSite.DrugUnits.Concat(requestedDrugs)
                                                         .ToList();

            country.Supplier.DrugUnits = country.Supplier.DrugUnits.Where(du => !requestedDrugs.Contains(du))
                                                                   .ToList();
            await _appDbContext.SaveChangesAsync();

            return View();
        }

    }
}