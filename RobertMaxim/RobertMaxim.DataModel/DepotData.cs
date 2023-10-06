using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim.DataModel
{
    public class DepotData
    {
        public string Name { get; set; }
        public string CountryName { get; set; }
        public string DrugTypeName { get; set; }
        public string DrugUnitId { get; set; }
        public int PickNumber { get; set; }

        public override string ToString()
        {
            return $"Depot name: {Name}; Country name: {CountryName}; Drug Type name: {DrugTypeName}; Drug Unit Id: {DrugUnitId}; Pick Number: {PickNumber}";
        }
    }
}
