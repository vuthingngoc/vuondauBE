using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public class HarvestSellingsController : Controller
    {
        private readonly VuondauDBContext _context;

        public HarvestSellingsController(VuondauDBContext context)
        {
            _context = context;
        }

        // GET: HarvestSellings
        public async Task<IActionResult> Index()
        {
            var vuondauDBContext = _context.HarvestSellings.Include(h => h.Harvest);
            return View(await vuondauDBContext.ToListAsync());
        }

        // GET: HarvestSellings/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestSelling = await _context.HarvestSellings
                .Include(h => h.Harvest)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (harvestSelling == null)
            {
                return NotFound();
            }

            return View(harvestSelling);
        }

        // GET: HarvestSellings/Create
        public IActionResult Create()
        {
            ViewData["HarvestId"] = new SelectList(_context.Harvests, "Id", "Id");
            return View();
        }

        // POST: HarvestSellings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HarvestId,DateOfCreate,MinWeight,TotalWeight")] HarvestSelling harvestSelling)
        {
            if (ModelState.IsValid)
            {
                _context.Add(harvestSelling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HarvestId"] = new SelectList(_context.Harvests, "Id", "Id", harvestSelling.HarvestId);
            return View(harvestSelling);
        }

        // GET: HarvestSellings/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestSelling = await _context.HarvestSellings.FindAsync(id);
            if (harvestSelling == null)
            {
                return NotFound();
            }
            ViewData["HarvestId"] = new SelectList(_context.Harvests, "Id", "Id", harvestSelling.HarvestId);
            return View(harvestSelling);
        }

        // POST: HarvestSellings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,HarvestId,DateOfCreate,MinWeight,TotalWeight")] HarvestSelling harvestSelling)
        {
            if (id != harvestSelling.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(harvestSelling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HarvestSellingExists(harvestSelling.Id))
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
            ViewData["HarvestId"] = new SelectList(_context.Harvests, "Id", "Id", harvestSelling.HarvestId);
            return View(harvestSelling);
        }

        // GET: HarvestSellings/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestSelling = await _context.HarvestSellings
                .Include(h => h.Harvest)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (harvestSelling == null)
            {
                return NotFound();
            }

            return View(harvestSelling);
        }

        // POST: HarvestSellings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var harvestSelling = await _context.HarvestSellings.FindAsync(id);
            _context.HarvestSellings.Remove(harvestSelling);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HarvestSellingExists(Guid id)
        {
            return _context.HarvestSellings.Any(e => e.Id == id);
        }
    }
}
