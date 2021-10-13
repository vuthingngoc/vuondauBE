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
    public class ProductPicturesController : Controller
    {
        private readonly VuondauDBContext _context;

        public ProductPicturesController(VuondauDBContext context)
        {
            _context = context;
        }

        // GET: ProductPictures
        public async Task<IActionResult> Index()
        {
            var vuondauDBContext = _context.ProductPictures.Include(p => p.Product);
            return View(await vuondauDBContext.ToListAsync());
        }

        // GET: ProductPictures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productPicture = await _context.ProductPictures
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productPicture == null)
            {
                return NotFound();
            }

            return View(productPicture);
        }

        // GET: ProductPictures/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: ProductPictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Src,Alt")] ProductPicture productPicture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productPicture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productPicture.ProductId);
            return View(productPicture);
        }

        // GET: ProductPictures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productPicture = await _context.ProductPictures.FindAsync(id);
            if (productPicture == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productPicture.ProductId);
            return View(productPicture);
        }

        // POST: ProductPictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ProductId,Src,Alt")] ProductPicture productPicture)
        {
            if (id != productPicture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productPicture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductPictureExists(productPicture.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productPicture.ProductId);
            return View(productPicture);
        }

        // GET: ProductPictures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productPicture = await _context.ProductPictures
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productPicture == null)
            {
                return NotFound();
            }

            return View(productPicture);
        }

        // POST: ProductPictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productPicture = await _context.ProductPictures.FindAsync(id);
            _context.ProductPictures.Remove(productPicture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductPictureExists(Guid id)
        {
            return _context.ProductPictures.Any(e => e.Id == id);
        }
    }
}
