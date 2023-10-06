using RobertMaxim.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim.DataModel
{
    public class DrugUnit
    {
        public string Id { get; set; }
        public int PickNumber { get; set; }
        public int TypeId { get; set; }
        public string? DepotId { get; set; }

        public DrugType Type { get; set; }
        public Depot? Depot { get; set; }

        public DrugUnit() { }
        public DrugUnit(string id, int pickNumber, DrugType type)
        {
            Id = id;
            PickNumber = pickNumber;
            Type = type;
        }

        public override string ToString() => $"Id: {Id}, PickNumber: {PickNumber}, Type: {Type.Name}, Depot: {Depot?.Name ?? "-"}";
    }
}
