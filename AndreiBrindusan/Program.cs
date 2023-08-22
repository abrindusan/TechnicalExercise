using AndreiBrindusan.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using AndreiBrindusan.Domain;
using AndreiBrindusan.Domain.CorrelationService;
using Microsoft.EntityFrameworkCore;
using AndreiBrindusan.Domain.DbService;

//using AppDbContext db = new AppDbContext();

namespace AndreiBrindusan
{
    class Program
    {
        public static DepotInventoryService depotInventoryService = new DepotInventoryService();

        

        public static void Print()
        {
            //var DataSet = SystemDataSetSingleton.Instance;
            using var db = new AppDbContext();
            
            Console.WriteLine("Countries:");
            var countries = db.Countries.Include(c => c.Depot).ToList();
            countries.ForEach(x => Console.WriteLine("ID:" + x.CountryID + " - " + x.CountryName + " -> Depot: " + x.Depot.DepotId));
            
            Console.WriteLine("Depots:");
            var depots = db.Depots.ToList();
            depots.ForEach(x => Console.WriteLine("ID:" + x.DepotId + " - " + x.DepotName));
            
            Console.WriteLine("Drug Units:");
            var drugUnits = db.DrugUnits.Include(d => d.DrugType).ToList();
            drugUnits.ForEach(x => Console.WriteLine("ID:" + x.DrugUnitId + " - " + x.DrugUnitName + " -> Order Number:" + x.PickNumber + " - Depot:" + x.DepotId + " - " + x.DrugType.DrugTypeName));
            
            Console.WriteLine("Drug Types");
            var drugTypes = db.DrugTypes.ToList();
            drugTypes.ForEach(x => Console.WriteLine("ID:" + x.DrugTypeId + " - " + x.DrugTypeName));
        }

        //public static void AssociateDrugs(string depotId, int startPickNumber, int endPickNumber)
        //{
        //    DataSet.DrugUnits.Where(
        //        x => x.PickNumber >= startPickNumber && x.PickNumber <= endPickNumber).ToList().ForEach(z => z.DepotId = depotId);
        //}

        //public static void DisassociateDrugs(int startPickNumber, int endPickNumber)
        //{
        //    DataSet.DrugUnits.Where(
        //        x => x.PickNumber >= startPickNumber && x.PickNumber <= endPickNumber).ToList().ForEach(z => z.DepotId = "No association with depot");
        //}

        //public static void GroupByDrugType()
        //{
        //    Dictionary<string,List<DrugUnit>> groupedDrugs = DataSet.DrugUnits.GroupBy(x => x.DrugType.DrugTypeName).ToDictionary(k => k.Key, k => k.ToList());
        //    foreach (var x in groupedDrugs)
        //    {
        //        Console.WriteLine(x.Key);
        //        x.Value.ForEach(y => Console.WriteLine(y.DrugUnitName));
        //        Console.WriteLine("\n");
        //    }
        //}

        public static void ModifyForSprint2()
        {

            var DataSet = SystemDataSetSingleton.Instance;
            using var db = new AppDbContext();
            List<DrugUnit> drugUnits = db.DrugUnits.Include(x => x.DrugType).ToList();
            List<Depot> depots = db.Depots.ToList();

            var groupedUnits = Extensions.ToGroupedDrugUnits(drugUnits);

            Console.WriteLine("Grouped Units: \n");
            foreach (var x in groupedUnits)
            {
                Console.WriteLine(x.Key);
                x.Value.ForEach(y => Console.WriteLine(y.DrugUnitName));
                Console.WriteLine("\n");
            }
            Console.WriteLine("Depot inventory:");
            DepotCorrelationService depotCorrelationService = new DepotCorrelationService(DataSet);
            var res = depotCorrelationService.CorrelateData();
            res.ForEach(x => Console.WriteLine(x.CountryName + " -" + x.DepotName + " -" + x.DrugTypeName + " -Drug Unit ID:" + x.DrugUnitId + " -" + x.PickNumber));
        }

        public static void ModifyForSprint3()
        {
            using var db = new AppDbContext();
            SiteDistributionService siteDistributionService = new SiteDistributionService(db);
            SiteInventoryDbHandler siteInventoryDbHandler = new SiteInventoryDbHandler();

            var distributedDrugUnits = siteDistributionService.GetRequestedDrugUnits("1", "Drug Type 1", 3);
            siteInventoryDbHandler.UpdateSiteInventory("1", "Drug Type 1", 10);
            Console.WriteLine("Available drugs: ");
            foreach (var item in distributedDrugUnits)
            {
                Console.WriteLine("Drug Unit ID: " + item.DrugUnitName + " - " + item.PickNumber + " -Drug Unit ID:" + item.DrugUnitId + " - Depot ID:" + item.DepotId + " - " + item.DrugType.DrugTypeName);
            }
        }

        // sprint 4
        
        public static void PopulateDataBase(SystemDataSet dataSet)
        {
            using var db = new AppDbContext();
            db.Countries.AddRange(dataSet.Countries);
            db.Depots.AddRange(dataSet.Depots);
            db.DrugUnits.AddRange(dataSet.DrugUnits);
            db.DrugTypes.AddRange(dataSet.DrugTypes);
            db.Sites.AddRange(dataSet.Sites);

            db.SaveChanges();
        }




        static void Main(string[] args)
        {
            var DataSet = SystemDataSetSingleton.Instance;
            Console.WriteLine("Initial Print");
            Print();
            Console.WriteLine("\n");
            Console.WriteLine("Association");
            // associate once
            //depotInventoryService.AssociateDrugs(DataSet.DrugUnits, DataSet.Depots.Select(x => x.DepotId).ToArray()[0], 50, 90);
            //depotInventoryService.AssociateDrugs(DataSet.DrugUnits, DataSet.Depots.Select(x => x.DepotId).ToArray()[1], 10, 45);
            Print();

            //depotInventoryService.AssociateDrugs(DataSet.DrugUnits, DataSet.Depots.Select(x => x.DepotId).ToArray()[0], 50, 90);
            //AssociateDrugs("1", 1, 50);
            //AssociateDrugs("2", 51, 99);
            //Print();
            //Console.WriteLine("\n");
            //Console.WriteLine("Disassociation");
            //depotInventoryService.DisassociateDrugs(DataSet.DrugUnits,65,80);
            //Print();
            Console.WriteLine("\n");
            ModifyForSprint2();
            Console.WriteLine("\n");
            ModifyForSprint3();
            //PopulateDataBase(DataSet); //just once
        }
    }
}
