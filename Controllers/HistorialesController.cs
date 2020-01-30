using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIM_Lubricentro.Data;
using SIM_Lubricentro.Models;

namespace SIM_Lubricentro.Controllers
{
    public class HistorialesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistorialesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Historiales
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Historial.Include(h => h.Carro).Include(h => h.Personal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Historiales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historial = await _context.Historial
                .Include(h => h.Carro)
                .Include(h => h.Personal)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (historial == null)
            {
                return NotFound();
            }

            return View(historial);
        }

        // GET: Historiales/Create
        public IActionResult Create()
        {
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID");
            ViewData["Personal_ID"] = new SelectList(_context.Personal, "ID", "ID");
            return View();
        }

        // POST: Historiales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Fecha,Carro_ID,Personal_ID")] Historial historial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID", historial.Carro_ID);
            ViewData["Personal_ID"] = new SelectList(_context.Personal, "ID", "ID", historial.Personal_ID);
            return View(historial);
        }

        // GET: Historiales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historial = await _context.Historial.FindAsync(id);
            if (historial == null)
            {
                return NotFound();
            }
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID", historial.Carro_ID);
            ViewData["Personal_ID"] = new SelectList(_context.Personal, "ID", "ID", historial.Personal_ID);
            return View(historial);
        }

        // POST: Historiales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Fecha,Carro_ID,Personal_ID")] Historial historial)
        {
            if (id != historial.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialExists(historial.ID))
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
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID", historial.Carro_ID);
            ViewData["Personal_ID"] = new SelectList(_context.Personal, "ID", "ID", historial.Personal_ID);
            return View(historial);
        }

        // GET: Historiales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historial = await _context.Historial
                .Include(h => h.Carro)
                .Include(h => h.Personal)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (historial == null)
            {
                return NotFound();
            }

            return View(historial);
        }

        // POST: Historiales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historial = await _context.Historial.FindAsync(id);
            _context.Historial.Remove(historial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialExists(int id)
        {
            return _context.Historial.Any(e => e.ID == id);
        }
    }
}
