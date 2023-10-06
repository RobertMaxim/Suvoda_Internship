using Microsoft.EntityFrameworkCore;
using RobertMaxim.DataModel;
using RobertMaxim.Domain.CorrelationService;
using RobertMaxim.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RobertMaxim.Web.Controllers
{
    public class DepotController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly DepotCorrelationService depotCorrelationService;

        public DepotController()
        {
            _appDbContext = new AppDbContext();
            depotCorrelationService = new DepotCorrelationService(_appDbContext);
        }

        public string Index()
        {
            return "Hello world";
        }

        [HttpGet]
        public ActionResult GetDepots()
        {
            List<DepotData> depotData = depotCorrelationService.CorrelateData()
                                                               .Where(d => !d.Name.Equals("-"))
                                                               .ToList();

            return View("DepotUnits", depotData);
        }

        public ActionResult ManageInventory()
        {
            List<Depot> depots = _appDbContext.Depots.ToList();

            return View("ManageInventory", depots);
        }

        public ActionResult DepotInventory()
        {
            double conversionToKilosFactor = 2.2;
            List<DepotInventoryViewModel> inventory = _appDbContext.Depots.SelectMany(depot => depot.DrugUnits, (depot, unit) => new DepotInventoryViewModel
            {
                DepotName = depot.Name,
                DrugTypeName = unit.Type.Name,
                TotalWeight = Math.Round((depot.DrugUnits.Count(du => du.Type.Name.Equals(unit.Type.Name)) * unit.Type.Weight / conversionToKilosFactor), 2)
            }).Distinct().ToList();

            return View("DepotInventory", inventory);
        }

        public async Task<ActionResult> AssociateDrugs(string depotName, int startPickNumber, int endPickNumber)
        {

            if (startPickNumber > endPickNumber)
            {
                ModelState.AddModelError("", "End Pick Number should be greater than Start Pick Number");
                return View("ManageInventory", _appDbContext.Depots.ToList());
            }

            List<DrugUnit> listOfValidDrugs = new List<DrugUnit>();
            Depot depot = _appDbContext.Depots.Where(d => d.Name.Equals(depotName))
                                              .First();

            foreach (DrugUnit drugUnit in _appDbContext.DrugUnits)
            {
                if (drugUnit.PickNumber >= startPickNumber
                    && drugUnit.PickNumber <= endPickNumber
                    && drugUnit.DepotId == null)
                {
                    listOfValidDrugs.Add(drugUnit);
                    drugUnit.Depot = depot;
                }
            }

            if (listOfValidDrugs.Count == 0)
            {
                ModelState.AddModelError("", "No drug units impacted");
                return View("ManageInventory", _appDbContext.Depots.ToList());
            }

            depot.DrugUnits = depot.DrugUnits?.Concat(listOfValidDrugs).ToList() ?? listOfValidDrugs;
            await _appDbContext.SaveChangesAsync();
            //To move this code to Service class
            return View("ManageInventory", _appDbContext.Depots.ToList());
        }

        public async Task<ActionResult> DisassociateDrugs(int startPickNumber, int endPickNumber)
        {
            if (startPickNumber > endPickNumber)
            {
                ModelState.AddModelError("", "End Pick Number should be greater than Start Pick Number");
                return View("ManageInventory", _appDbContext.Depots.ToList());
            }

            foreach (DrugUnit drugUnit in _appDbContext.DrugUnits)
            {
                if (drugUnit.PickNumber >= startPickNumber && drugUnit.PickNumber <= endPickNumber)
                {
                    drugUnit.DepotId = null;
                }
            }

            foreach (Depot depot in _appDbContext.Depots)
            {
                if (depot.DrugUnits != null && depot.DrugUnits.Count > 0)
                {
                    depot.DrugUnits.ToList().RemoveAll(du => du.PickNumber <= startPickNumber
                                                               || du.PickNumber >= endPickNumber);
                }
            }

            await _appDbContext.SaveChangesAsync();
            return View("ManageInventory", _appDbContext.Depots.ToList());
        }
    }
}