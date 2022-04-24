using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MP_MulheresProgramando.Models;

namespace MP_MulheresProgramando.Controllers
{
    public class ProgramadorasController : Controller
    {
        private readonly Context _context;

        public ProgramadorasController(Context context)
        {
            _context = context;
        }

        // GET: Programadoras
        public async Task<IActionResult> Index()
        {
            var context = _context.Programadoras.Include(p => p.Linguagens);
            return View(await context.ToListAsync());
        }

        // GET: Programadoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programadora = await _context.Programadoras
                .Include(p => p.Linguagens)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programadora == null)
            {
                return NotFound();
            }

            return View(programadora);
        }

        // GET: Programadoras/Create
        public IActionResult Create()
        {
            ViewData["LinguagemId"] = new SelectList(_context.Linguagens, "Id", "Nome");
            return View();
        }

        // POST: Programadoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeDev,LinguagemId")] Programadora programadora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programadora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LinguagemId"] = new SelectList(_context.Linguagens, "Id", "Nome", programadora.LinguagemId);
            return View(programadora);
        }

        // GET: Programadoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programadora = await _context.Programadoras.FindAsync(id);
            if (programadora == null)
            {
                return NotFound();
            }
            ViewData["LinguagemId"] = new SelectList(_context.Linguagens, "Id", "Nome", programadora.LinguagemId);
            return View(programadora);
        }

        // POST: Programadoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeDev,LinguagemId")] Programadora programadora)
        {
            if (id != programadora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programadora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramadoraExists(programadora.Id))
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
            ViewData["LinguagemId"] = new SelectList(_context.Linguagens, "Id", "Nome", programadora.LinguagemId);
            return View(programadora);
        }

        // GET: Programadoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programadora = await _context.Programadoras
                .Include(p => p.Linguagens)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programadora == null)
            {
                return NotFound();
            }

            return View(programadora);
        }

        // POST: Programadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programadora = await _context.Programadoras.FindAsync(id);
            _context.Programadoras.Remove(programadora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramadoraExists(int id)
        {
            return _context.Programadoras.Any(e => e.Id == id);
        }
    }
}
