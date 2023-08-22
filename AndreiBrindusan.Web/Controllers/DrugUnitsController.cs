using AndreiBrindusan.DataModel;
using AndreiBrindusan.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndreiBrindusan.Web.Controllers
{
    public class DrugUnitsController : Controller
    {
        private readonly AppContext _context;

        public DrugUnitsController(AppContext context)
        {
            _context = context;
        }
        // GET: DrugUnitsController
        public async Task<IActionResult> Index()
        {
            return _context.DrugUnits.Include(x => x.DrugType.DrugTypeId) != null ? View(await _context.DrugUnits.ToListAsync()) :
                Problem("Entity set 'AppContext.DrugUnits' is null.");
        }

        // GET: DrugUnitsController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DrugUnits == null)
            {
                return NotFound();
            }

            var drugUnit = await _context.DrugUnits
                .Include(x=>x.DrugType)
                .FirstOrDefaultAsync(m => m.DrugUnitId == id);

            
                
            if (drugUnit == null)
            {
                return NotFound();
            }
            return View(drugUnit);
        }

        // GET: DrugUnitsController/Create
        public IActionResult Create()
        {
            ViewBag.DrugTypes = new SelectList(_context.DrugTypes, "DrugTypeId", "DrugTypeName");
            return View();
        }

        // POST: DrugUnitsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrugUnitId,PickNumber,DrugUnitName,DepotId,DrugType")] DrugUnit drugUnit)
        {
            if (ModelState.IsValid)
            {
                // Fetch the existing DrugType using the DrugTypeId
                drugUnit.DrugType = await _context.DrugTypes.FindAsync(drugUnit.DrugType.DrugTypeId);

                _context.Add(drugUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DrugTypes = new SelectList(_context.DrugTypes, "DrugTypeId", "DrugTypeName", drugUnit.DrugType?.DrugTypeId);

            return View(drugUnit);
        }

        // GET: DrugUnitsController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DrugUnits == null)
            {
                return NotFound();
            }

            var drugUnit = await _context.DrugUnits.FindAsync(id);
            if (drugUnit == null)
            {
                return NotFound();
            }
            return View(drugUnit);
        }

        // POST: DrugUnitsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DrugUnitId,PickNumber,DrugUnitName,DepotId,DrugType.DrugTypeId")] DrugUnit drugUnit)
        {
            if (id != drugUnit.DrugUnitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drugUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrugUnitExists(drugUnit.DepotId))
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
            return View(drugUnit);
        }

        // GET: DrugUnitsController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DrugUnits == null)
            {
                return NotFound();
            }

            var drugUnit = await _context.DrugUnits.FirstOrDefaultAsync(m => m.DrugUnitId == id);
            if (drugUnit == null)
            {
                return NotFound();
            }
            return View(drugUnit);
        }

        // POST: DrugUnitsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            if (_context.DrugUnits == null)
            {
                return Problem("Entity set 'AppContext.DrugUnits' is null.");
            }
            var drugUnit = await _context.DrugUnits.FindAsync(id);
            if (drugUnit != null)
            {
                _context.DrugUnits.Remove(drugUnit);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public bool DrugUnitExists(string id)
        {
            return (_context.DrugUnits?.Any(e => e.DrugUnitId == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Grouped()
        {
            Dictionary<string, List<DrugUnit>> groupedDrugs = _context.DrugUnits
                .Include(x => x.DrugType)
                .AsEnumerable()
                .GroupBy(x => x.DrugType.DrugTypeName)
                .ToDictionary(g => g.Key, g => g.ToList());
            return View(groupedDrugs);

        }

        public async Task<IActionResult> Weights()
        {
            var allDrugUnits = await _context.DrugUnits
                .Include(x => x.DrugType)
                .ToListAsync();

            var groupedDrugs = allDrugUnits
                .GroupBy(x => new { x.DrugType.DrugTypeName, x.DepotId })
                .Select(c => new GroupedWeights
                {
                    DepotId = c.Key.DepotId,
                    DrugTypeName = c.Key.DrugTypeName,
                    GroupedDrugs = c.ToList(),
                    Weight = c.Sum(x => x.DrugType.Weight) / 2.2
                })
                .ToList();

            return View(groupedDrugs);
        }
    }
}
