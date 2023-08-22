using AndreiBrindusan.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreiBrindusan.Domain
{
    public static class Extensions
    {
        public static Dictionary<string, List<DrugUnit>> ToGroupedDrugUnits(IList<DrugUnit> drugUnits)
        {
            var groupedUnits = drugUnits.GroupBy(x => x.DrugType.DrugTypeName);

            var dictionary = groupedUnits.ToDictionary(k => k.Key, v => v.ToList());

            return dictionary;
        }
    }
}
