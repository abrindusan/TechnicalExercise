using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreiBrindusan.Domain.DbService
{
    public class SiteInventoryDbHandler : ISiteInventoryDbHandler
    {
        public void UpdateSiteInventory(string destinationSiteId, string requestedDrugCode, int requestedQuantity)
                {
                    SiteDistributionService siteDistributionService = new SiteDistributionService(new DataModel.AppDbContext());
                }
    }
}
