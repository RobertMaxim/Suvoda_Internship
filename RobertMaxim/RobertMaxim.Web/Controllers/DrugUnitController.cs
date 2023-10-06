using Microsoft.EntityFrameworkCore;
using RobertMaxim.DataModel;
using RobertMaxim.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RobertMaxim.Web.Controllers
{
    public class DrugUnitController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public DrugUnitController()
        {
            _appDbContext = new AppDbContext();
        }

        public ActionResult Index()
        {
            List<DrugUnit> drugUnits = _appDbContext.DrugUnits.Include(du=>du.Type)
                                                              .Include(du=>du.Depot)
                                                              .ToList();

            Dictionary<string, List<DrugUnit>> groupedDrugs = drugUnits.ToGroupedDrugUnits();

            return View("DrugUnits", groupedDrugs);
        }
    }
}