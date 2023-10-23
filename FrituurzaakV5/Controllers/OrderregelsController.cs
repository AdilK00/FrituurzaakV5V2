using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrituurzaakV5.Data;
using FrituurzaakV5.Models;

namespace FrituurzaakV5.Controllers
{
    public class OrderregelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderregelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orderregels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orderregel.Include(o => o.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Orderregels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orderregel == null)
            {
                return NotFound();
            }

            var orderregel = await _context.Orderregel
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderregel == null)
            {
                return NotFound();
            }

            return View(orderregel);
        }

        // GET: Orderregels/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            return View();
        }

        // POST: Orderregels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Amount")] Orderregel orderregel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderregel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", orderregel.ProductId);
            return View(orderregel);
        }

        // GET: Orderregels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orderregel == null)
            {
                return NotFound();
            }

            var orderregel = await _context.Orderregel.FindAsync(id);
            if (orderregel == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", orderregel.ProductId);
            return View(orderregel);
        }

        // POST: Orderregels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Amount")] Orderregel orderregel)
        {
            if (id != orderregel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderregel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderregelExists(orderregel.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", orderregel.ProductId);
            return View(orderregel);
        }

        // GET: Orderregels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orderregel == null)
            {
                return NotFound();
            }

            var orderregel = await _context.Orderregel
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderregel == null)
            {
                return NotFound();
            }

            return View(orderregel);
        }

        // POST: Orderregels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orderregel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Orderregel'  is null.");
            }
            var orderregel = await _context.Orderregel.FindAsync(id);
            if (orderregel != null)
            {
                _context.Orderregel.Remove(orderregel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderregelExists(int id)
        {
          return (_context.Orderregel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
