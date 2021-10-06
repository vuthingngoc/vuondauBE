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
    public class FarmPicturesController : Controller
    {
        private readonly VuondauDBContext _context;

        public FarmPicturesController(VuondauDBContext context)
        {
            _context = context;
        }

        // GET: FarmPictures
        public async Task<IActionResult> Index()
        {
            var vuondauDBContext = _context.FarmPictures.Include(f => f.Farm);
            return View(await vuondauDBContext.ToListAsync());
        }

        // GET: FarmPictures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmPicture = await _context.FarmPictures
                .Include(f => f.Farm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (farmPicture == null)
            {
                return NotFound();
            }

            return View(farmPicture);
        }

        // GET: FarmPictures/Create
        public IActionResult Create()
        {
            ViewData["FarmId"] = new SelectList(_context.Farms, "Id", "Id");
            return View();
        }

        // POST: FarmPictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FarmId,Src,Alt")] FarmPicture farmPicture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmPicture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FarmId"] = new SelectList(_context.Farms, "Id", "Id", farmPicture.FarmId);
            return View(farmPicture);
        }

        // GET: FarmPictures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmPicture = await _context.FarmPictures.FindAsync(id);
            if (farmPicture == null)
            {
                return NotFound();
            }
            ViewData["FarmId"] = new SelectList(_context.Farms, "Id", "Id", farmPicture.FarmId);
            return View(farmPicture);
        }

        // POST: FarmPictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FarmId,Src,Alt")] FarmPicture farmPicture)
        {
            if (id != farmPicture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmPicture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmPictureExists(farmPicture.Id))
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
            ViewData["FarmId"] = new SelectList(_context.Farms, "Id", "Id", farmPicture.FarmId);
            return View(farmPicture);
        }

        // GET: FarmPictures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmPicture = await _context.FarmPictures
                .Include(f => f.Farm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (farmPicture == null)
            {
                return NotFound();
            }

            return View(farmPicture);
        }

        // POST: FarmPictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmPicture = await _context.FarmPictures.FindAsync(id);
            _context.FarmPictures.Remove(farmPicture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmPictureExists(int id)
        {
            return _context.FarmPictures.Any(e => e.Id == id);
        }
    }
}
