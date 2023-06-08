using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MohInpatient.Data;
using MohInpatient.Models;

namespace MohInpatient.Controllers
{
    public class InpatientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InpatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inpatients
        public async Task<IActionResult> Index()
        {
              return _context.inpatients != null ? 
                          View(await _context.inpatients.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.inpatients'  is null.");
        }

        // GET: Inpatients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.inpatients == null)
            {
                return NotFound();
            }

            var inpatient = await _context.inpatients
                .FirstOrDefaultAsync(m => m.InpatientId == id);
            if (inpatient == null)
            {
                return NotFound();
            }

            return View(inpatient);
        }

        // GET: Inpatients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inpatients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Inpatient inpatient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inpatient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inpatient);
        }

        // GET: Inpatients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.inpatients == null)
            {
                return NotFound();
            }

            var inpatient = await _context.inpatients.FindAsync(id);
            if (inpatient == null)
            {
                return NotFound();
            }
            return View(inpatient);
        }

        // POST: Inpatients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Inpatient inpatient)
        {
            if (id != inpatient.InpatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inpatient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InpatientExists(inpatient.InpatientId))
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
            return View(inpatient);
        }

        // GET: Inpatients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.inpatients == null)
            {
                return NotFound();
            }

            var inpatient = await _context.inpatients
                .FirstOrDefaultAsync(m => m.InpatientId == id);
            if (inpatient == null)
            {
                return NotFound();
            }

            return View(inpatient);
        }

        // POST: Inpatients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.inpatients == null)
            {
                return Problem("Entity set 'ApplicationDbContext.inpatients'  is null.");
            }
            var inpatient = await _context.inpatients.FindAsync(id);
            if (inpatient != null)
            {
                _context.inpatients.Remove(inpatient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InpatientExists(int id)
        {
          return (_context.inpatients?.Any(e => e.InpatientId == id)).GetValueOrDefault();
        }
    }
}
