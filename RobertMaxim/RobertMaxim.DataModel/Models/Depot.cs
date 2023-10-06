using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim.DataModel
{
    public class Depot
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int ProvenienceId { get; set; }

        public Country Provenience { get; set; }
        public ICollection<DrugUnit> DrugUnits { get; set; }
        public ICollection<Country> CountriesSupplied { get; set; }

        public override string ToString() => $"Id: {Id}, " +
                                             $"Name: {Name}, " +
                                             $"Countries: {string.Join(", ", CountriesSupplied.Select(t => t.Name))}, " +
                                             $"DrugUnits: { (DrugUnits != null&& DrugUnits.Count>0 ? string.Join("; ", DrugUnits.Select(u=>u.Id)):"-")}";
    }
}
