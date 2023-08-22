using AndreiBrindusan.Web.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreiBrindusan.Web.Controllers
{
    public class RequestedDrugsController : Controller
    {
        private readonly AppContext _context;

        public RequestedDrugsController(AppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string SiteId,string DrugCode, int Quantity)
        {
            RequestService service = new RequestService(_context);
            return View(service.GetRequestedDrugUnits(SiteId, DrugCode, Quantity));
        }
    }
}
