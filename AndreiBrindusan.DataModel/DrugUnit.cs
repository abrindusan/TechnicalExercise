using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreiBrindusan.DataModel
{
    [Table(name: "DrugUnit")]
    public class DrugUnit
    {
        [Key]
        public string DrugUnitId { get; set; }
        public int PickNumber { get; set; }

        public string DrugUnitName { get; set; }
        public string DepotId { get; set; }
        public DrugType DrugType { get; set; }
    }
}
