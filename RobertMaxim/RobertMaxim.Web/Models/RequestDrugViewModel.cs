using RobertMaxim.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobertMaxim.Web.Models
{
    public class RequestDrugViewModel
    {
        public Site Site { get; set; }
        public List<DrugType> DrugTypes { get; set; }
    }
}