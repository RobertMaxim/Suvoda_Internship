using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobertMaxim.DataModel;

namespace RobertMaxim.Domain.CorrelationService
{
    public class DepotCorrelationService : BaseCorrelationService<DepotData>
    {
        private readonly AppDbContext _appDbContext;
        //public DepotCorrelationService(SystemDataSet systemDataSet) : base(systemDataSet)
        //{ }

        public DepotCorrelationService(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public override List<DepotData> CorrelateData()
        {
            List<DepotData> correlatedList = _appDbContext.DrugUnits.Select(drugUnit =>
                                                    new DepotData()
                                                    {
                                                        Name = drugUnit.Depot != null ? drugUnit.Depot.Name : "-",
                                                        CountryName = drugUnit.Depot != null ? drugUnit.Depot.Provenience.Name : "-",
                                                        DrugUnitId = drugUnit.Id,
                                                        DrugTypeName = drugUnit.Type.Name,
                                                        PickNumber = drugUnit.PickNumber
                                                    }
                                               ).ToList();
            
            return correlatedList;
        }
    }
}

