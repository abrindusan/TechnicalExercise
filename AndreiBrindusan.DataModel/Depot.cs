using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreiBrindusan.DataModel
{
    [Table(name: "Depot")]
    public class Depot
    {
        [Key]
        public string DepotId { get; set; }
        public string DepotName { get; set; }

        public ICollection<Country> Countries { get; set; } = new List<Country>();
    }
}
