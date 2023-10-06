using RobertMaxim.DataModel;
using RobertMaxim.Domain;
using RobertMaxim.Domain.CorrelationService;
using RobertMaxim.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobertMaxim
{
    class Program
    {
        public static SystemDataSet DataSet = new SystemDataSet();
        static async Task Main(string[] args)
        {    
            AppDbContext appDbContext = new AppDbContext();
            List<DrugUnit> drugUnitList = (List<DrugUnit>)DataSet.DrugUnits;
            List<Depot> depots = (List<Depot>)DataSet.Depots;

            //Printing the collections
            Printer.PrintCollections(DataSet.Countries);
            Printer.PrintCollections(DataSet.Depots);
            Printer.PrintCollections(DataSet.DrugTypes);
            Printer.PrintCollections(DataSet.DrugUnits);

            //Association and Disassociation for first sprint ex
            //System.Console.WriteLine("First association starts here");
            //DepotHandler.AssociateDrugs("APH-1", 10, 150);
            //DepotHandler.AssociateDrugs("NFR-2", 35, 150);
            //Printer.PrintCollections(DataSet.Depots);

            //System.Console.WriteLine("Disassociation starts here");
            //DepotHandler.DisassociateDrugs(40, 150);
            //Printer.PrintCollections(DataSet.Depots);

            //first ex dictionary
            //Dictionary<string, List<DrugUnit>> dictionary = DrugUnitHandler.Map();
            //Printer.PrintDictionary(dictionary);

            //----------------------------------------------
            
            //Association and disassociation for second sprint ex, followed by some printers for depot collection
            DepotInventoryService depotInventoryService = new DepotInventoryService(appDbContext);

            System.Console.WriteLine("Association starts here");
            depotInventoryService.AssociateDrugs("APH-1", 10, 50);
            depotInventoryService.AssociateDrugs("NFR-2", 40, 150);

            Printer.PrintCollections(DataSet.Depots);

            System.Console.WriteLine("Disassociation starts here");
            depotInventoryService.DisassociateDrugs(75, 130);
            Printer.PrintCollections(DataSet.Depots);


            //second version of dictionary as sprint 2 ex requests'
            Dictionary<string, List<DrugUnit>> dictionary = drugUnitList.ToGroupedDrugUnits();
            Printer.PrintDictionary(dictionary);

            //data correlation and printer
            DepotCorrelationService depotCorrelationService = new DepotCorrelationService(appDbContext);
            List<DepotData> depotCorrelatedData = depotCorrelationService.CorrelateData();

            Printer.PrintCollections(depotCorrelatedData);

            //Distribution of the drugs in the given site and print of the request
            SiteDistributionService siteDistributionService = new SiteDistributionService(DataSet);
            IEnumerable<DrugUnit> requestedDrugs = siteDistributionService.GetRequestedDrugUnits("A", "Paracetamol", 5);
            
            Printer.PrintDrugRequest(requestedDrugs);

            //Adding a Depot in the database
            Repository<Country> countriesRepository= new Repository<Country>(appDbContext);
            Country countryToBeAdded = new Country()
            {
                Name = "USA"
            };

            await countriesRepository.Add(countryToBeAdded);
        }
    }
}
