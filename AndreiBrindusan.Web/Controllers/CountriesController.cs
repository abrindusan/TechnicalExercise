using AndreiBrindusan.DataModel;
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
    public class CountriesController : Controller
    {
        private readonly AppContext _context;

        public CountriesController(AppContext context)
        {
            _context = context;
        }
        // GET: CountriesController
        public async Task<IActionResult> Index()
        {
            var appContext = _context.Countries.Include(c => c.Depot);
            return View(await appContext.ToListAsync());
        }

        // GET: CountriesController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if(id==null || _context.Countries == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.Include(c => c.Depot).FirstOrDefaultAsync(m => m.CountryID == id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // GET: CountriesController/Create
        public IActionResult Create()
        {
            ViewData["DepotId"] = new SelectList(_context.Depots, "DepotId", "DepotId");
            return View();
        }

        // POST: CountriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryID,CountryName,Depot")] Country country)
        {
            if (ModelState.IsValid)
            {
                country.Depot = await _context.Depots.FindAsync(country.Depot.DepotId);
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepotId"] = new SelectList(_context.Depots, "DepotId", "DepotId", country.Depot.DepotId);
            return View(country);
        }

        // GET: CountriesController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.FindAsync(id);
            var completeCountry = _context.Countries.Include(c => c.Depot).FirstOrDefault(x => x.CountryID == country.CountryID);
            if (completeCountry == null)
            {
                return NotFound();
            }

            ViewData["DepotId"] = new SelectList(_context.Depots, "DepotId", "DepotId", completeCountry.Depot.DepotId);
            return View(completeCountry);
        }

        // POST: CountriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CountryID,CountryName,Depot")] Country country)
        {
            if (id != country.CountryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Fetch the selected Depot from the database using the given DepotId
                    var selectedDepot = await _context.Depots
                        .FirstOrDefaultAsync(d => d.DepotId == country.Depot.DepotId);

                    if (selectedDepot == null)
                    {
                        return NotFound("Selected Depot not found.");
                    }

                    // Update the associated Country's Depot properties
                    country.Depot = selectedDepot;

                    // Save changes to the database
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.CountryID))
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

            // If ModelState is not valid, re-populate the Depot dropdown
            ViewData["DepotId"] = new SelectList(_context.Depots, "DepotId", "DepotId", country.Depot.DepotId);
            return View(country);
        }

        // GET: CountriesController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.Include(c => c.Depot).FirstOrDefaultAsync(m => m.CountryID == id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: CountriesController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            if(_context.Countries == null)
            {
                return Problem("Entity set 'AppContext.Countries' is null.");
            }
            var country = await _context.Countries.FindAsync(id);
            if(country != null)
            {
                _context.Countries.Remove(country);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public bool CountryExists(string id)
        {
            return (_context.Countries?.Any(e => e.CountryID == id)).GetValueOrDefault();
        }
    }
}
