using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndreiBrindusan.DataModel
{
    [Table(name:"Country")]
    public class Country
    {
        [Key]
        public string CountryID { get; set; }
        public string CountryName { get; set; }

        public Depot Depot { get; set; }
    }
}
