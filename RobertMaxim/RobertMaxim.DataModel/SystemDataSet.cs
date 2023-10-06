using RobertMaxim.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim.DataModel
{
    public class SystemDataSet
    {
        public ICollection<Country> Countries { get; set; }
        public ICollection<Depot> Depots { get; set; }
        public ICollection<DrugUnit> DrugUnits { get; set; }
        public ICollection<DrugType> DrugTypes { get; set; }
        public ICollection<Site> Sites { get; set; }

        public SystemDataSet()
        {
            Countries = new List<Country>
            {
                new Country() { Id = 1, Name = "Romania" },
                new Country() { Id = 2, Name = "USA" }
            };

            //Setted as default the provenience country as first from the countries list (Romania) as it is an example
            Depots = new List<Depot>
            {
                new Depot() { Id = "APH-1", Name = "Alphafarm", Provenience=Countries.First(), CountriesSupplied = Countries.Where(c=>c.Id==1).ToArray() },
                new Depot() { Id = "NFR-2", Name = "Netfarma", Provenience=Countries.First(), CountriesSupplied = Countries.Where(c=>c.Id==2).ToArray() }
            };

            foreach (Country country in Countries)
            {
                country.Supplier = Depots.FirstOrDefault(depot => depot.CountriesSupplied.Contains(country));
            }

            DrugTypes = new List<DrugType>
            {
                new DrugType() { Id = 1, Name = "Paracetamol" },
                new DrugType() { Id = 2, Name = "Nurofen" }
            };

            DrugUnits = new List<DrugUnit>();
            Random random = new Random();

            for (int i = 1; i < 11; i++)
            {
                DrugUnits.Add(new DrugUnit($"PRM-{i * 50}", random.Next(1, 201), DrugTypes.First(dt => dt.Id == 1)));
            }

            for (int i = 1; i < 11; i++)
            {
                DrugUnits.Add(new DrugUnit($"{i * 25}-NUR", random.Next(1, 201), DrugTypes.First(dt => dt.Id == 2)));
            }

            Sites = new List<Site>()
            {
                new Site() { Id="A", Name="University of Clinical Studies", CountryCode = 1},
                new Site() { Id="B", Name="Municipal Hospital", CountryCode = 2}
            };

        }
    }
}
