using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreiBrindusan.DataModel;
using AndreiBrindusan;
using Microsoft.EntityFrameworkCore;

namespace AndreiBrindusan.Domain
{
    
    public class SiteDistributionService : ISiteDistributionService
    {
        protected readonly AppDbContext data;
        public SiteDistributionService(AppDbContext db)
        {
            this.data = db;
        }
        //public static SystemDataSet DataSet { get; set; } = new SystemDataSet();
        public static DepotInventoryService depotInventoryService = new DepotInventoryService();
        public IEnumerable<DrugUnit> GetRequestedDrugUnits(string siteId, string drugCode, int quantity)
        {
            //var DataSet = SystemDataSetSingleton.Instance;
            using var db = new AppDbContext();
            var site = db.Sites.FirstOrDefault(s => s.SiteId == siteId);
            if (site == null)
            {
                Console.WriteLine("Site not found");
            }

            // Find the country that the site is located in

            var country = db.Countries.FirstOrDefault(c => c.CountryID == site.CountryCode);
            if (country == null)
            {
                Console.WriteLine("Site has an invalid country code");
            }

            var depots = db.Depots.Include(x=>x.Countries).ToList();
            // Find depot in the country
            var countryDepot = depots.Where(x => x.Countries.Any(c => c.CountryID == country.CountryID)).FirstOrDefault();

            var drugUnits = db.DrugUnits.Include(d => d.DrugType).ToList();
            // Find the drug units of the req type
            var requestedDrugUnits = drugUnits.Where(d => d.DepotId == countryDepot.DepotId && d.DrugType.DrugTypeName == drugCode).ToList();

            // Check if there are enough drug units for the requested quantity
            if (requestedDrugUnits.Count() < quantity)
            {
                Console.WriteLine("Not enough drug units available ({0})",quantity);
            }

            return requestedDrugUnits;

        }
    }
}
