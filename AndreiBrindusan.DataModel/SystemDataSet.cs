using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreiBrindusan.DataModel
{
    public class SystemDataSet
    {
        public List<Country> Countries { get; set; }
        public List<Depot> Depots { get; set; }
        public List<DrugUnit> DrugUnits { get; set; }
        public List<DrugType> DrugTypes { get; set; }
        public List<Site> Sites { get; set; }


        public SystemDataSet()
        {
            Sites = new List<Site>
            {
                new Site { SiteId = "1", SiteName = "Site 1", CountryCode = "1"},
                new Site { SiteId = "2", SiteName = "Site 2", CountryCode = "2"}
            };
            // First create the Depots because we need to associate countries with them
            Depots = new List<Depot>
            {
                new Depot {DepotId = "1", DepotName = "Depot 1"},
                new Depot {DepotId = "2", DepotName = "Depot 2"}
            };

            Countries = new List<Country>
            {
                new Country {CountryID = "1", CountryName = "Romania" }, //Depot = Depots[0]},
                new Country {CountryID = "2", CountryName = "Bulgaria" }//, Depot = Depots[1]}
            };

            // set up the relationships
            Countries[0].Depot = Depots[0];
            Depots[0].Countries.Add(Countries[0]);

            Countries[1].Depot = Depots[1];
            Depots[1].Countries.Add(Countries[1]);


            DrugTypes = new List<DrugType>
            {
                new DrugType {DrugTypeId = "1", DrugTypeName = "Drug Type 1"},
                new DrugType {DrugTypeId = "2", DrugTypeName = "Drug Type 2"}
            };

            // Create 20 Drug Units
            var rand = new Random();
            DrugUnits = new List<DrugUnit>();
            for(int i = 1; i <=20; i++)
            {
                var drugUnit = new DrugUnit
                {
                    DrugUnitId = i.ToString(),
                    DrugUnitName = "Unit " + i,
                    PickNumber = rand.Next(100),
                    DepotId = "No association with depot",
                    DrugType = DrugTypes[rand.Next(DrugTypes.Count)]
                };
                DrugUnits.Add(drugUnit);
            }

            
        }
    }
}
