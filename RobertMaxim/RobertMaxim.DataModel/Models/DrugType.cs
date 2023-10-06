using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim.DataModel
{
    public class DrugType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public ICollection<DrugUnit> DrugUnits { get; set; }
        public override string ToString() => $"Id: {Id}, Name: {Name}";
    }
}
