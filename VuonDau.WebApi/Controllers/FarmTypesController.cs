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
    public class FarmTypesController : Controller
    {
        private readonly VuondauDBContext _context;

        public FarmTypesController(VuondauDBContext context)
        {
            _context = context;
        }

        // GET: FarmTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FarmTypes.ToListAsync());
        }

        // GET: FarmTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmType = await _context.FarmTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (farmType == null)
            {
                return NotFound();
            }

            return View(farmType);
        }

        // GET: FarmTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FarmTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] FarmType farmType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmType);
        }

        // GET: FarmTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmType = await _context.FarmTypes.FindAsync(id);
            if (farmType == null)
            {
                return NotFound();
            }
            return View(farmType);
        }

        // POST: FarmTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description")] FarmType farmType)
        {
            if (id != farmType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmTypeExists(farmType.Id))
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
            return View(farmType);
        }

        // GET: FarmTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmType = await _context.FarmTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (farmType == null)
            {
                return NotFound();
            }

            return View(farmType);
        }

        // POST: FarmTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var farmType = await _context.FarmTypes.FindAsync(id);
            _context.FarmTypes.Remove(farmType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmTypeExists(string id)
        {
            return _context.FarmTypes.Any(e => e.Id == id);
        }
    }
}
