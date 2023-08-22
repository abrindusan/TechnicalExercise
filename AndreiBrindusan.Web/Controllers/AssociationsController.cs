using AndreiBrindusan.Web.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreiBrindusan.Web.Controllers
{
    public class AssociationsController : Controller
    {
        private readonly AppContext _context;

        public AssociationsController(AppContext context)
        {
            _context = context;
        }
        // GET: AssociationsController
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string DepotId, int StartPickNumber,int EndPickNumber, string Operation)
        {
            InventoryService service = new InventoryService(_context);
            switch (Operation)
            {
                case "Associate":
                    service.AssociateDrugs(DepotId, StartPickNumber, EndPickNumber);
                    break;
                case "Dissociate":
                    service.DisassociateDrugs(StartPickNumber, EndPickNumber);
                    break;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
