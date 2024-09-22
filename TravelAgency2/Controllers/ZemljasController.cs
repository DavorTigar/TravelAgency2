using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelAgency2.Data;
using TravelAgency2.Models;

namespace TravelAgency2.Controllers
{
    [Authorize]
    public class ZemljasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZemljasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zemljas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zemlja.ToListAsync());
        }

        // GET: Zemljas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zemlja = await _context.Zemlja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zemlja == null)
            {
                return NotFound();
            }

            return View(zemlja);
        }

        // GET: Zemljas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zemljas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImeZemlje")] Zemlja zemlja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zemlja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zemlja);
        }

        // GET: Zemljas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zemlja = await _context.Zemlja.FindAsync(id);
            if (zemlja == null)
            {
                return NotFound();
            }
            return View(zemlja);
        }

        // POST: Zemljas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImeZemlje")] Zemlja zemlja)
        {
            if (id != zemlja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zemlja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZemljaExists(zemlja.Id))
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
            return View(zemlja);
        }

        // GET: Zemljas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zemlja = await _context.Zemlja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zemlja == null)
            {
                return NotFound();
            }

            return View(zemlja);
        }

        // POST: Zemljas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zemlja = await _context.Zemlja.FindAsync(id);
            if (zemlja != null)
            {
                _context.Zemlja.Remove(zemlja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZemljaExists(int id)
        {
            return _context.Zemlja.Any(e => e.Id == id);
        }
    }
}
