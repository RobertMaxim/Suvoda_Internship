using RobertMaxim.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace RobertMaxim.Domain
{
    public static class Extensions
    {
        public static Dictionary<string, List<DrugUnit>> ToGroupedDrugUnits(this IList<DrugUnit> drugUnits)
        {
            Dictionary<string, List<DrugUnit>> drugsDict = new Dictionary<string, List<DrugUnit>>();
            List<DrugType> types = drugUnits.Select(du => du.Type)
                                            .Distinct()
                                            .ToList();
            types.ForEach(type =>
            {
                List<DrugUnit> drugUnitsForType = drugUnits.Where(du => du.Type.Name.Equals(type.Name))
                                                           .ToList();
                drugsDict.Add(type.Name, drugUnitsForType);
            });

            return drugsDict;
        }
    }
}
