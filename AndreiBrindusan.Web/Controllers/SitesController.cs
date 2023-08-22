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
    public class SitesController : Controller
    {
        private readonly AppContext _context;

        public SitesController(AppContext context)
        {
            _context = context;
        }
        // GET: SitesController
        public async Task<IActionResult> Index()
        {
            return _context.Sites != null ? View(await _context.Sites.ToListAsync()) :
                Problem("Entity set 'AppContext.Sites' is null.");
        }

        // GET: SitesController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Sites == null)
            {
                return NotFound();
            }

            var site = await _context.Sites.FirstOrDefaultAsync(m => m.SiteId == id);
            if (site == null)
            {
                return NotFound();
            }
            return View(site);
        }

        // GET: SitesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SitesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SiteId,SiteName,CountryCode")] Site site)
        {
            if (ModelState.IsValid)
            {
                _context.Add(site);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(site);
        }

        // GET: SitesController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Sites == null)
            {
                return NotFound();
            }

            var site = await _context.Sites.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }
            return View(site);
        }

        // POST: SitesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SiteId,SiteName,CountryCode")] Site site)
        {
            if (id != site.SiteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(site);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteExists(site.SiteId))
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
            return View(site);
        }

        // GET: SitesController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Sites == null)
            {
                return NotFound();
            }

            var site = await _context.Sites.FirstOrDefaultAsync(m => m.SiteId == id);
            if (site == null)
            {
                return NotFound();
            }
            return View(site);
        }

        // POST: SitesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            if (_context.Sites == null)
            {
                return Problem("Entity set 'AppContext.Sites' is null.");
            }
            var site = await _context.Sites.FindAsync(id);
            if (site != null)
            {
                _context.Sites.Remove(site);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public bool SiteExists(string id)
        {
            return (_context.Sites?.Any(e => e.SiteId == id)).GetValueOrDefault();
        }
    }
}
