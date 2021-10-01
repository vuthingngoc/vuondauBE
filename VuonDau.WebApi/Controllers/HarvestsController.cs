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
    public class HarvestsController : Controller
    {
        private readonly VuondauDBContext _context;

        public HarvestsController(VuondauDBContext context)
        {
            _context = context;
        }

        // GET: Harvests
        public async Task<IActionResult> Index()
        {
            var vuondauDBContext = _context.Harvests.Include(h => h.Farm).Include(h => h.Product);
            return View(await vuondauDBContext.ToListAsync());
        }

        // GET: Harvests/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvest = await _context.Harvests
                .Include(h => h.Farm)
                .Include(h => h.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (harvest == null)
            {
                return NotFound();
            }

            return View(harvest);
        }

        // GET: Harvests/Create
        public IActionResult Create()
        {
            ViewData["FarmId"] = new SelectList(_context.Farms, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: Harvests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FarmId,ProductId,Description")] Harvest harvest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(harvest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FarmId"] = new SelectList(_context.Farms, "Id", "Id", harvest.FarmId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", harvest.ProductId);
            return View(harvest);
        }

        // GET: Harvests/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvest = await _context.Harvests.FindAsync(id);
            if (harvest == null)
            {
                return NotFound();
            }
            ViewData["FarmId"] = new SelectList(_context.Farms, "Id", "Id", harvest.FarmId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", harvest.ProductId);
            return View(harvest);
        }

        // POST: Harvests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,FarmId,ProductId,Description")] Harvest harvest)
        {
            if (id != harvest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(harvest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HarvestExists(harvest.Id))
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
            ViewData["FarmId"] = new SelectList(_context.Farms, "Id", "Id", harvest.FarmId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", harvest.ProductId);
            return View(harvest);
        }

        // GET: Harvests/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvest = await _context.Harvests
                .Include(h => h.Farm)
                .Include(h => h.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (harvest == null)
            {
                return NotFound();
            }

            return View(harvest);
        }

        // POST: Harvests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var harvest = await _context.Harvests.FindAsync(id);
            _context.Harvests.Remove(harvest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HarvestExists(string id)
        {
            return _context.Harvests.Any(e => e.Id == id);
        }
    }
}
