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
    public class RealizarReparacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RealizarReparacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RealizarReparaciones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RealizarReparacion.Include(r => r.Carro).Include(r => r.Personal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RealizarReparaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realizarReparacion = await _context.RealizarReparacion
                .Include(r => r.Carro)
                .Include(r => r.Personal)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (realizarReparacion == null)
            {
                return NotFound();
            }

            return View(realizarReparacion);
        }

        // GET: RealizarReparaciones/Create
        public IActionResult Create()
        {
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID");
            ViewData["Personal_ID"] = new SelectList(_context.Personal, "ID", "ID");
            return View();
        }

        // POST: RealizarReparaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Realizado,Carro_ID,Personal_ID")] RealizarReparacion realizarReparacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(realizarReparacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID", realizarReparacion.Carro_ID);
            ViewData["Personal_ID"] = new SelectList(_context.Personal, "ID", "ID", realizarReparacion.Personal_ID);
            return View(realizarReparacion);
        }

        // GET: RealizarReparaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realizarReparacion = await _context.RealizarReparacion.FindAsync(id);
            if (realizarReparacion == null)
            {
                return NotFound();
            }
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID", realizarReparacion.Carro_ID);
            ViewData["Personal_ID"] = new SelectList(_context.Personal, "ID", "ID", realizarReparacion.Personal_ID);
            return View(realizarReparacion);
        }

        // POST: RealizarReparaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Realizado,Carro_ID,Personal_ID")] RealizarReparacion realizarReparacion)
        {
            if (id != realizarReparacion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(realizarReparacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealizarReparacionExists(realizarReparacion.ID))
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
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID", realizarReparacion.Carro_ID);
            ViewData["Personal_ID"] = new SelectList(_context.Personal, "ID", "ID", realizarReparacion.Personal_ID);
            return View(realizarReparacion);
        }

        // GET: RealizarReparaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realizarReparacion = await _context.RealizarReparacion
                .Include(r => r.Carro)
                .Include(r => r.Personal)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (realizarReparacion == null)
            {
                return NotFound();
            }

            return View(realizarReparacion);
        }

        // POST: RealizarReparaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var realizarReparacion = await _context.RealizarReparacion.FindAsync(id);
            _context.RealizarReparacion.Remove(realizarReparacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RealizarReparacionExists(int id)
        {
            return _context.RealizarReparacion.Any(e => e.ID == id);
        }
    }
}
