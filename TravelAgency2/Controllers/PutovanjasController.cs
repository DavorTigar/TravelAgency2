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
    public class PutovanjasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PutovanjasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Putovanjas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Putovanja.ToListAsync());
        }

        // GET: Putovanjas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var putovanja = await _context.Putovanja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (putovanja == null)
            {
                return NotFound();
            }

            return View(putovanja);
        }

        // GET: Putovanjas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Putovanjas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImeZemlje,ImeAerodroma")] Putovanja putovanja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(putovanja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(putovanja);
        }

        // GET: Putovanjas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var putovanja = await _context.Putovanja.FindAsync(id);
            if (putovanja == null)
            {
                return NotFound();
            }
            return View(putovanja);
        }

        // POST: Putovanjas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImeZemlje,ImeAerodroma")] Putovanja putovanja)
        {
            if (id != putovanja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(putovanja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PutovanjaExists(putovanja.Id))
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
            return View(putovanja);
        }

        // GET: Putovanjas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var putovanja = await _context.Putovanja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (putovanja == null)
            {
                return NotFound();
            }

            return View(putovanja);
        }

        // POST: Putovanjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var putovanja = await _context.Putovanja.FindAsync(id);
            if (putovanja != null)
            {
                _context.Putovanja.Remove(putovanja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PutovanjaExists(int id)
        {
            return _context.Putovanja.Any(e => e.Id == id);
        }
    }
}
