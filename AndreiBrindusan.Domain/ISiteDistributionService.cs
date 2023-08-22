using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreiBrindusan.DataModel;

namespace AndreiBrindusan.Domain
{
    interface ISiteDistributionService
    {
        public IEnumerable<DrugUnit> GetRequestedDrugUnits(string siteId, string drugCode, int quantity);
    }
}
