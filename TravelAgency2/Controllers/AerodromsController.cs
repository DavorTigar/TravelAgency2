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
    public class AerodromsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AerodromsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aerodroms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aerodrom.ToListAsync());
        }

        // GET: Aerodroms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aerodrom = await _context.Aerodrom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aerodrom == null)
            {
                return NotFound();
            }

            return View(aerodrom);
        }

        // GET: Aerodroms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aerodroms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImeAerodroma")] Aerodrom aerodrom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aerodrom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aerodrom);
        }

        // GET: Aerodroms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aerodrom = await _context.Aerodrom.FindAsync(id);
            if (aerodrom == null)
            {
                return NotFound();
            }
            return View(aerodrom);
        }

        // POST: Aerodroms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImeAerodroma")] Aerodrom aerodrom)
        {
            if (id != aerodrom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aerodrom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AerodromExists(aerodrom.Id))
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
            return View(aerodrom);
        }

        // GET: Aerodroms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aerodrom = await _context.Aerodrom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aerodrom == null)
            {
                return NotFound();
            }

            return View(aerodrom);
        }

        // POST: Aerodroms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aerodrom = await _context.Aerodrom.FindAsync(id);
            if (aerodrom != null)
            {
                _context.Aerodrom.Remove(aerodrom);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AerodromExists(int id)
        {
            return _context.Aerodrom.Any(e => e.Id == id);
        }
    }
}
