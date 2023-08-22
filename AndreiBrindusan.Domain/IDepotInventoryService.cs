using AndreiBrindusan.DataModel;
using System;
using System.Collections.Generic;

namespace AndreiBrindusan.Domain
{
    interface IDepotInventoryService
    {
        void AssociateDrugs(List<DrugUnit> drugUnits, string depotId, int startPickNumber, int endPickNumber);
        void DisassociateDrugs(List<DrugUnit> drugUnits, int startPickNumber, int endPickNumber);
    }
}
