using System;
using AndreiBrindusan.DataModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreiBrindusan.Domain
{
    public class DepotInventoryService : IDepotInventoryService
    {
        public void AssociateDrugs(List<DrugUnit> drugUnits, string depotId, int startPickNumber, int endPickNumber)
        {
            using var db = new AppDbContext();
            drugUnits.Where(
                x => x.PickNumber >= startPickNumber && x.PickNumber <= endPickNumber).ToList()
                .ForEach(z => z.DepotId = depotId);
            foreach (var drugUnit in drugUnits)
            {
                db.DrugUnits.Update(drugUnit);
                db.SaveChanges();
            }
        }

        public void DisassociateDrugs(List<DrugUnit> drugUnits, int startPickNumber, int endPickNumber)
        {
            using var db = new AppDbContext();
            drugUnits.Where(
                x => x.PickNumber >= startPickNumber && x.PickNumber <= endPickNumber).ToList()
                .ForEach(z => z.DepotId = "No association with depot");
            foreach (var drugUnit in drugUnits)
            {
                db.DrugUnits.Update(drugUnit);
                db.SaveChanges();
            }
        }
    }
}
