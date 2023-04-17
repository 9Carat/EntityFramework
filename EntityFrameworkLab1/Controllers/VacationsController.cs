using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkLab1.Data;
using EntityFrameworkLab1.Models;

namespace EntityFrameworkLab1.Controllers
{
    public class VacationsController : Controller
    {
        private readonly VacationDbContext _context;

        public VacationsController(VacationDbContext context)
        {
            _context = context;
        }

        // GET: Vacations
        public async Task<IActionResult> Index()
        {
            var vacationDbContext = _context.Vacations.Include(v => v.Employees);
            return View(await vacationDbContext.ToListAsync());
        }

        // GET: Vacations/VacationSearch
        public async Task<IActionResult> VacationSearch()
        {
            var vacationDbContext = _context.Vacations.Include(v => v.Employees);
            return View(await vacationDbContext.ToListAsync());
        }

        // Post: Vacations/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string VacationSearch)
        {
            var vacationDbContext = _context.Vacations.Include(v => v.Employees);
            return View("Index", await vacationDbContext.Where(v => v.Employees.LastName.Contains(VacationSearch)).ToListAsync());
        }

        // GET: Vacations/Admin
        public async Task<IActionResult> Admin()
        {
            var vacationDbContext = _context.Vacations.Include(v => v.Employees);
            return View(await vacationDbContext.ToListAsync());
        }

        // Post: Vacations/AdminShowResults
        public async Task<IActionResult> AdminShowResults(DateTime SearchStart, DateTime SearchEnd)
        {
            var vacationDbContext = _context.Vacations.Include(v => v.Employees);
            return View("Index", await vacationDbContext.Where(v => v.ApplyDate > SearchStart && v.ApplyDate < SearchEnd).ToListAsync()) ;
        }


        // GET: Vacations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vacations == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacations
                .Include(v => v.Employees)
                .FirstOrDefaultAsync(m => m.VacationId == id);
            if (vacation == null)
            {
                return NotFound();
            }

            return View(vacation);
        }

        // GET: Vacations/Create
        public IActionResult Create()
        {
            ViewData["FK_EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId");
            return View();
        }

        // POST: Vacations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacationId,VacationType,VacationStart,VacationEnd,ApplyDate,FK_EmpId")] Vacation vacation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId", vacation.FK_EmpId);
            return View(vacation);
        }

        // GET: Vacations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vacations == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacations.FindAsync(id);
            if (vacation == null)
            {
                return NotFound();
            }
            ViewData["FK_EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId", vacation.FK_EmpId);
            return View(vacation);
        }

        // POST: Vacations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacationId,VacationType,VacationStart,VacationEnd,ApplyDate,FK_EmpId")] Vacation vacation)
        {
            if (id != vacation.VacationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacationExists(vacation.VacationId))
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
            ViewData["FK_EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId", vacation.FK_EmpId);
            return View(vacation);
        }

        // GET: Vacations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vacations == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacations
                .Include(v => v.Employees)
                .FirstOrDefaultAsync(m => m.VacationId == id);
            if (vacation == null)
            {
                return NotFound();
            }

            return View(vacation);
        }

        // POST: Vacations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vacations == null)
            {
                return Problem("Entity set 'VacationDbContext.Vacations'  is null.");
            }
            var vacation = await _context.Vacations.FindAsync(id);
            if (vacation != null)
            {
                _context.Vacations.Remove(vacation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacationExists(int id)
        {
          return (_context.Vacations?.Any(e => e.VacationId == id)).GetValueOrDefault();
        }
    }
}
