using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobertMaxim.Web.Models
{
    public class DepotInventoryViewModel
    {
        public string DepotName { get; set; }
        public string DrugTypeName { get; set; }
        public double TotalWeight { get; set; }
    }
}