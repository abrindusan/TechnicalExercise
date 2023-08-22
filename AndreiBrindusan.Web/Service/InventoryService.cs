using AndreiBrindusan.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreiBrindusan.Web.Service
{
    public class InventoryService
    {
        private readonly AppContext db;

        public InventoryService(AppContext context)
        {
            db = context;
        }

        public void AssociateDrugs(string depotId,int startPickNumber, int endPickNumber)
        {
            List<DrugUnit> drugUnits = new List<DrugUnit>();
            drugUnits = db.DrugUnits.Where(x => x.PickNumber >= startPickNumber && x.PickNumber <= endPickNumber).ToList();
            drugUnits.ForEach(z => z.DepotId = depotId);

            foreach (var drugUnit in drugUnits)
            {
                db.DrugUnits.Update(drugUnit);
                db.SaveChanges();
            }
        }

        public void DisassociateDrugs(int startPickNumber,int endPickNumber)
        {
            List<DrugUnit> drugUnits = new List<DrugUnit>();
            drugUnits = db.DrugUnits.Where(x => x.PickNumber >= startPickNumber && x.PickNumber <= endPickNumber).ToList();
            drugUnits.ForEach(z => z.DepotId = "No association with depot");
            foreach (var drugUnit in drugUnits)
            {
                db.DrugUnits.Update(drugUnit);
                db.SaveChanges();
            }
        }
    }
}
