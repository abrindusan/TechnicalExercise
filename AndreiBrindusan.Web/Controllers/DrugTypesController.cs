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
    public class DrugTypesController : Controller
    {
        private readonly AppContext _context;

        public DrugTypesController(AppContext context)
        {
            _context = context;
        }
        // GET: DrugTypesController
        public async Task<IActionResult> Index()
        {
            return _context.DrugTypes != null ? View(await _context.DrugTypes.ToListAsync()) :
                Problem("Entity set 'AppContext.DrugTypes' is null.");
        }

        // GET: DrugTypesController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DrugTypes == null)
            {
                return NotFound();
            }

            var drugType = await _context.DrugTypes.FirstOrDefaultAsync(m => m.DrugTypeId == id);
            if (drugType == null)
            {
                return NotFound();
            }
            return View(drugType);
        }

        // GET: DrugTypesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DrugTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrugTypeId,DrugTypeName")] DrugType drugType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drugType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drugType);
        }

        // GET: DrugTypesController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DrugTypes == null)
            {
                return NotFound();
            }

            var drugType = await _context.DrugTypes.FindAsync(id);
            if (drugType == null)
            {
                return NotFound();
            }
            return View(drugType);
        }

        // POST: DrugTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DrugTypeId,DrugTypeName")] DrugType drugType)
        {
            if (id != drugType.DrugTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drugType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrugTypeExists(drugType.DrugTypeId))
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
            return View(drugType);
        }

        // GET: DrugTypesController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DrugTypes == null)
            {
                return NotFound();
            }

            var drugType = await _context.DrugTypes.FirstOrDefaultAsync(m => m.DrugTypeId == id);
            if (drugType == null)
            {
                return NotFound();
            }
            return View(drugType);
        }
        // POST: DrugTypesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            if (_context.DrugTypes == null)
            {
                return Problem("Entity set 'AppContext.DrugTypes' is null.");
            }
            var drugType = await _context.DrugTypes.FindAsync(id);
            if (drugType != null)
            {
                _context.DrugTypes.Remove(drugType);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public bool DrugTypeExists(string id)
        {
            return (_context.DrugTypes?.Any(e => e.DrugTypeId == id)).GetValueOrDefault();
        }
    }
}
