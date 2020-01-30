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
    public class PiezaAgregadasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PiezaAgregadasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PiezaAgregadas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PiezaAgregada.Include(p => p.Carro);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PiezaAgregadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piezaAgregada = await _context.PiezaAgregada
                .Include(p => p.Carro)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (piezaAgregada == null)
            {
                return NotFound();
            }

            return View(piezaAgregada);
        }

        // GET: PiezaAgregadas/Create
        public IActionResult Create()
        {
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID");
            return View();
        }

        // POST: PiezaAgregadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CodigoProducto,Descripcion,FechaPiezaAgregada,Carro_ID")] PiezaAgregada piezaAgregada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(piezaAgregada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID", piezaAgregada.Carro_ID);
            return View(piezaAgregada);
        }

        // GET: PiezaAgregadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piezaAgregada = await _context.PiezaAgregada.FindAsync(id);
            if (piezaAgregada == null)
            {
                return NotFound();
            }
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID", piezaAgregada.Carro_ID);
            return View(piezaAgregada);
        }

        // POST: PiezaAgregadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CodigoProducto,Descripcion,FechaPiezaAgregada,Carro_ID")] PiezaAgregada piezaAgregada)
        {
            if (id != piezaAgregada.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(piezaAgregada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PiezaAgregadaExists(piezaAgregada.ID))
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
            ViewData["Carro_ID"] = new SelectList(_context.Carro, "ID", "ID", piezaAgregada.Carro_ID);
            return View(piezaAgregada);
        }

        // GET: PiezaAgregadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piezaAgregada = await _context.PiezaAgregada
                .Include(p => p.Carro)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (piezaAgregada == null)
            {
                return NotFound();
            }

            return View(piezaAgregada);
        }

        // POST: PiezaAgregadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var piezaAgregada = await _context.PiezaAgregada.FindAsync(id);
            _context.PiezaAgregada.Remove(piezaAgregada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PiezaAgregadaExists(int id)
        {
            return _context.PiezaAgregada.Any(e => e.ID == id);
        }
    }
}
