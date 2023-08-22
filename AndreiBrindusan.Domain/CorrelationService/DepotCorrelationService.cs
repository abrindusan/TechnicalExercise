using AndreiBrindusan.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreiBrindusan.Domain.CorrelationService
{
    public class DepotCorrelationService : BaseCorellationService<List<CorrelateDataModel>>
    {
        public DepotCorrelationService(SystemDataSet dataSet) : base(dataSet) { }
        public override List<CorrelateDataModel> CorrelateData()
        {
            using var db = new AppDbContext();
            List<Depot> depots = db.Depots.ToList();
            List<DrugUnit> drugUnits = db.DrugUnits.Include(x => x.DrugType).ToList();
            List<Country> countries = db.Countries.Include(y => y.Depot).ToList();



            var res = (from du in drugUnits
                       join dp in depots on du.DepotId equals (dp.DepotId) into depotss
                       from dps in depotss
                       join c in countries on dps.DepotId equals (c.Depot.DepotId) into countriess
                       from cs in countriess
                       select new CorrelateDataModel { CountryName = cs.CountryName, DepotName = dps?.DepotName, DrugTypeName = du.DrugType.DrugTypeName, DrugUnitId = du.DrugUnitId, PickNumber = du.PickNumber }).ToList();
            

            return res;
        }
    }
}
