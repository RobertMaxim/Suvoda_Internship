using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim.DataModel
{
    public class Site
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int CountryCode { get; set; }
        
        public ICollection<DrugUnit> DrugUnits { get; set; }

        public override string ToString()
        {
            return $"Site ID: {Id}; Name: {Name};";
        }
    }
}
