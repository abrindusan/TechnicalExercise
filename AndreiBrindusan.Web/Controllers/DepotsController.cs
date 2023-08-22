using AndreiBrindusan.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreiBrindusan.Web.Controllers
{
    public class DepotsController : Controller
    {
        private readonly AppContext _context;

        public DepotsController(AppContext context)
        {
            _context = context;
        }
        // GET: DepotsController
        public async Task<IActionResult> Index()
        {
            return _context.Depots != null ? View(await _context.Depots.ToListAsync()) :
                Problem("Entity set 'AppContext.Depots' is null.");
        }

        // GET: DepotsController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Depots == null)
            {
                return NotFound();
            }

            var depot = await _context.Depots.FirstOrDefaultAsync(m => m.DepotId == id);
            depot.Countries = _context.Countries
                .Where(x => x.Depot.DepotId == depot.DepotId)
                .ToList();
            if (depot == null)
            {
                return NotFound();
            }
            return View(depot);
        }

        // GET: DepotsController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DepotsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepotId,DepotName")] Depot depot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(depot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(depot);
        }

        // GET: DepotsController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Depots == null)
            {
                return NotFound();
            }

            var depot = await _context.Depots.FindAsync(id);
            if (depot == null)
            {
                return NotFound();
            }
            return View(depot);
        }
        // POST: DepotsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,[Bind("DepotId,DepotName")] Depot depot)
        {
            if (id != depot.DepotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(depot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepotExists(depot.DepotId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(depot);
        }

        // GET: DepotsController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Depots == null)
            {
                return NotFound();
            }

            var depot = await _context.Depots.FirstOrDefaultAsync(m => m.DepotId == id);
            if (depot == null)
            {
                return NotFound();
            }
            return View(depot);
        }
        // POST: DepotsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            if (_context.Depots == null)
            {
                return Problem("Entity set 'AppContext.Depots' is null.");
            }
            var depot = await _context.Depots.FindAsync(id);
            if (depot != null)
            {
                _context.Depots.Remove(depot);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public bool DepotExists(string id)
        {
            return (_context.Depots?.Any(e => e.DepotId == id)).GetValueOrDefault();
        }
    }
}
