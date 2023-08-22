using AndreiBrindusan.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreiBrindusan.Web
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Depot> Depots { get; set; }
        public DbSet<DrugType> DrugTypes { get; set; }
        public DbSet<DrugUnit> DrugUnits { get; set; }
        public DbSet<Site> Sites { get; set; }
    }
}
