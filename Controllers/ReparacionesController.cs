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
    public class ReparacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReparacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reparaciones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reparacion.Include(r => r.Carro).Include(r => r.Personal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reparaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparacion = await _context.Reparacion
                .Include(r => r.Carro)
                .Include(r => r.Personal)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reparacion == null)
            {
                return NotFound();
            }

            return View(reparacion);
        }

        // GET: Reparaciones/Create
        public IActionResult Create()
        {
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID");
            ViewData["Personal_ID"] = new SelectList(_context.Personal, "ID", "ID");
            return View();
        }

        // POST: Reparaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,Descripcion,Realizado,Fecha,Carro_ID,Personal_ID")] Reparacion reparacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reparacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID", reparacion.Carro_ID);
            ViewData["Personal_ID"] = new SelectList(_context.Personal, "ID", "ID", reparacion.Personal_ID);
            return View(reparacion);
        }

        // GET: Reparaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparacion = await _context.Reparacion.FindAsync(id);
            if (reparacion == null)
            {
                return NotFound();
            }
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID", reparacion.Carro_ID);
            ViewData["Personal_ID"] = new SelectList(_context.Personal, "ID", "ID", reparacion.Personal_ID);
            return View(reparacion);
        }

        // POST: Reparaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,Descripcion,Realizado,Fecha,Carro_ID,Personal_ID")] Reparacion reparacion)
        {
            if (id != reparacion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reparacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReparacionExists(reparacion.ID))
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
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID", reparacion.Carro_ID);
            ViewData["Personal_ID"] = new SelectList(_context.Personal, "ID", "ID", reparacion.Personal_ID);
            return View(reparacion);
        }

        // GET: Reparaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reparacion = await _context.Reparacion
                .Include(r => r.Carro)
                .Include(r => r.Personal)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reparacion == null)
            {
                return NotFound();
            }

            return View(reparacion);
        }

        // POST: Reparaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reparacion = await _context.Reparacion.FindAsync(id);
            _context.Reparacion.Remove(reparacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReparacionExists(int id)
        {
            return _context.Reparacion.Any(e => e.ID == id);
        }
    }
}
