using RobertMaxim.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace RobertMaxim
{
    class DrugUnitHandler
    {
        static public Dictionary<string,List<DrugUnit>> Map()
        {
            Dictionary<string, List<DrugUnit>> drugsDict = new Dictionary<string, List<DrugUnit>>();
            foreach (DrugType type in Program.DataSet.DrugTypes)
            {
                List<DrugUnit> drugUnitsForType = Program.DataSet.DrugUnits.Where(du => du.Type.Name.Equals(type.Name))
                                                                           .ToList();
                drugsDict.Add(type.Name, drugUnitsForType);
            }

            return drugsDict;
        }
    }
}
