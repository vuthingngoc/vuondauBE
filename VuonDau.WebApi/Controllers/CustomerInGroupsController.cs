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
    public class CustomerInGroupsController : Controller
    {
        private readonly VuondauDBContext _context;

        public CustomerInGroupsController(VuondauDBContext context)
        {
            _context = context;
        }

        // GET: CustomerInGroups
        public async Task<IActionResult> Index()
        {
            var vuondauDBContext = _context.CustomerInGroups.Include(c => c.Customer).Include(c => c.CustomerGroup);
            return View(await vuondauDBContext.ToListAsync());
        }

        // GET: CustomerInGroups/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerInGroup = await _context.CustomerInGroups
                .Include(c => c.Customer)
                .Include(c => c.CustomerGroup)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerInGroup == null)
            {
                return NotFound();
            }

            return View(customerInGroup);
        }

        // GET: CustomerInGroups/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["CustomerGroupId"] = new SelectList(_context.CustomerGroups, "Id", "Id");
            return View();
        }

        // POST: CustomerInGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerGroupId,JoinDate")] CustomerInGroup customerInGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerInGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", customerInGroup.CustomerId);
            ViewData["CustomerGroupId"] = new SelectList(_context.CustomerGroups, "Id", "Id", customerInGroup.CustomerGroupId);
            return View(customerInGroup);
        }

        // GET: CustomerInGroups/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerInGroup = await _context.CustomerInGroups.FindAsync(id);
            if (customerInGroup == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", customerInGroup.CustomerId);
            ViewData["CustomerGroupId"] = new SelectList(_context.CustomerGroups, "Id", "Id", customerInGroup.CustomerGroupId);
            return View(customerInGroup);
        }

        // POST: CustomerInGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CustomerId,CustomerGroupId,JoinDate")] CustomerInGroup customerInGroup)
        {
            if (id != customerInGroup.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerInGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerInGroupExists(customerInGroup.CustomerId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", customerInGroup.CustomerId);
            ViewData["CustomerGroupId"] = new SelectList(_context.CustomerGroups, "Id", "Id", customerInGroup.CustomerGroupId);
            return View(customerInGroup);
        }

        // GET: CustomerInGroups/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerInGroup = await _context.CustomerInGroups
                .Include(c => c.Customer)
                .Include(c => c.CustomerGroup)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerInGroup == null)
            {
                return NotFound();
            }

            return View(customerInGroup);
        }

        // POST: CustomerInGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customerInGroup = await _context.CustomerInGroups.FindAsync(id);
            _context.CustomerInGroups.Remove(customerInGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerInGroupExists(string id)
        {
            return _context.CustomerInGroups.Any(e => e.CustomerId == id);
        }
    }
}
