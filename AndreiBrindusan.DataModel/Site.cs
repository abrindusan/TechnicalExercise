using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreiBrindusan.DataModel
{
    [Table(name: "Site")]
    public class Site
    {
        [Key]
        public string SiteId { get; set; }
        public string SiteName { get; set; }

        public string CountryCode { get; set; }
    }
}
