using AndreiBrindusan.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreiBrindusan.Web.Models
{
    public class GroupedWeights
    {
        public string DrugTypeName { get; set; }
        public string DepotId { get; set; }
        public List<DrugUnit> GroupedDrugs { get; set; }
        public double Weight { get; set; }
    }
}
