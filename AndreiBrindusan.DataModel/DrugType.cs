using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreiBrindusan.DataModel
{
    [Table(name: "DrugType")]
    public class DrugType
    {
        [Key]
        public string DrugTypeId { get; set; }
        public string DrugTypeName { get; set; }

        public int Weight { get; set; }

    }
}
