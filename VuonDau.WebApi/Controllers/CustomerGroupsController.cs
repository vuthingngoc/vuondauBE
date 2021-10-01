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
    public class CustomerGroupsController : Controller
    {
        private readonly VuondauDBContext _context;

        public CustomerGroupsController(VuondauDBContext context)
        {
            _context = context;
        }

        // GET: CustomerGroups
        public async Task<IActionResult> Index()
        {
            var vuondauDBContext = _context.CustomerGroups.Include(c => c.HarvestSelling);
            return View(await vuondauDBContext.ToListAsync());
        }

        // GET: CustomerGroups/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerGroup = await _context.CustomerGroups
                .Include(c => c.HarvestSelling)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerGroup == null)
            {
                return NotFound();
            }

            return View(customerGroup);
        }

        // GET: CustomerGroups/Create
        public IActionResult Create()
        {
            ViewData["HarvestSellingId"] = new SelectList(_context.HarvestSellings, "Id", "Id");
            return View();
        }

        // POST: CustomerGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location,HarvestSellingId")] CustomerGroup customerGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HarvestSellingId"] = new SelectList(_context.HarvestSellings, "Id", "Id", customerGroup.HarvestSellingId);
            return View(customerGroup);
        }

        // GET: CustomerGroups/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerGroup = await _context.CustomerGroups.FindAsync(id);
            if (customerGroup == null)
            {
                return NotFound();
            }
            ViewData["HarvestSellingId"] = new SelectList(_context.HarvestSellings, "Id", "Id", customerGroup.HarvestSellingId);
            return View(customerGroup);
        }

        // POST: CustomerGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Location,HarvestSellingId")] CustomerGroup customerGroup)
        {
            if (id != customerGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerGroupExists(customerGroup.Id))
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
            ViewData["HarvestSellingId"] = new SelectList(_context.HarvestSellings, "Id", "Id", customerGroup.HarvestSellingId);
            return View(customerGroup);
        }

        // GET: CustomerGroups/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerGroup = await _context.CustomerGroups
                .Include(c => c.HarvestSelling)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerGroup == null)
            {
                return NotFound();
            }

            return View(customerGroup);
        }

        // POST: CustomerGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customerGroup = await _context.CustomerGroups.FindAsync(id);
            _context.CustomerGroups.Remove(customerGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerGroupExists(string id)
        {
            return _context.CustomerGroups.Any(e => e.Id == id);
        }
    }
}
