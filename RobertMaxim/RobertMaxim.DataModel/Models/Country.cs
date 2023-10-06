using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim.DataModel
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? SupplierId { get;set; } 
        public Depot? Supplier { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}, Supplier: {Supplier.Name}";
    }
}
