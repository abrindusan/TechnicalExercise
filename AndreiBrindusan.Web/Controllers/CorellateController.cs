using AndreiBrindusan.Web.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreiBrindusan.Web.Controllers
{
    public class CorellateController : Controller
    {
        private readonly AppContext _context;

        public CorellateController(AppContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            CorellationService service = new CorellationService(_context);
            return View(service.CorrelateData());
        }
    }
}
