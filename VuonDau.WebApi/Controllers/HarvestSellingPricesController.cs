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
    public class HarvestSellingPricesController : Controller
    {
        private readonly VuondauDBContext _context;

        public HarvestSellingPricesController(VuondauDBContext context)
        {
            _context = context;
        }

        // GET: HarvestSellingPrices
        public async Task<IActionResult> Index()
        {
            var vuondauDBContext = _context.HarvestSellingPrices.Include(h => h.HarvestSelling);
            return View(await vuondauDBContext.ToListAsync());
        }

        // GET: HarvestSellingPrices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestSellingPrice = await _context.HarvestSellingPrices
                .Include(h => h.HarvestSelling)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (harvestSellingPrice == null)
            {
                return NotFound();
            }

            return View(harvestSellingPrice);
        }

        // GET: HarvestSellingPrices/Create
        public IActionResult Create()
        {
            ViewData["HarvestSellingId"] = new SelectList(_context.HarvestSellings, "Id", "Id");
            return View();
        }

        // POST: HarvestSellingPrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,HarvestSellingId")] HarvestSellingPrice harvestSellingPrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(harvestSellingPrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HarvestSellingId"] = new SelectList(_context.HarvestSellings, "Id", "Id", harvestSellingPrice.HarvestSellingId);
            return View(harvestSellingPrice);
        }

        // GET: HarvestSellingPrices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestSellingPrice = await _context.HarvestSellingPrices.FindAsync(id);
            if (harvestSellingPrice == null)
            {
                return NotFound();
            }
            ViewData["HarvestSellingId"] = new SelectList(_context.HarvestSellings, "Id", "Id", harvestSellingPrice.HarvestSellingId);
            return View(harvestSellingPrice);
        }

        // POST: HarvestSellingPrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Price,HarvestSellingId")] HarvestSellingPrice harvestSellingPrice)
        {
            if (id != harvestSellingPrice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(harvestSellingPrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!HarvestSellingPriceExists(harvestSellingPrice.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HarvestSellingId"] = new SelectList(_context.HarvestSellings, "Id", "Id", harvestSellingPrice.HarvestSellingId);
            return View(harvestSellingPrice);
        }

        // GET: HarvestSellingPrices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestSellingPrice = await _context.HarvestSellingPrices
                .Include(h => h.HarvestSelling)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (harvestSellingPrice == null)
            {
                return NotFound();
            }

            return View(harvestSellingPrice);
        }

        // POST: HarvestSellingPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var harvestSellingPrice = await _context.HarvestSellingPrices.FindAsync(id);
            _context.HarvestSellingPrices.Remove(harvestSellingPrice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HarvestSellingPriceExists(Guid id)
        {
            return _context.HarvestSellingPrices.Any(e => e.Id == id);
        }
    }
}
