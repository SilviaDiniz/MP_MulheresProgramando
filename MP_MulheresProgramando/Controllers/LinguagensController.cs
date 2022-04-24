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
    public class LinguagensController : Controller
    {
        private readonly Context _context;

        public LinguagensController(Context context)
        {
            _context = context;
        }

        // GET: Linguagens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Linguagens.ToListAsync());
        }

        // GET: Linguagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linguagem = await _context.Linguagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linguagem == null)
            {
                return NotFound();
            }

            return View(linguagem);
        }

        // GET: Linguagens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Linguagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Linguagem linguagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linguagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(linguagem);
        }

        // GET: Linguagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linguagem = await _context.Linguagens.FindAsync(id);
            if (linguagem == null)
            {
                return NotFound();
            }
            return View(linguagem);
        }

        // POST: Linguagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Linguagem linguagem)
        {
            if (id != linguagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linguagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinguagemExists(linguagem.Id))
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
            return View(linguagem);
        }

        // GET: Linguagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linguagem = await _context.Linguagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linguagem == null)
            {
                return NotFound();
            }

            return View(linguagem);
        }

        // POST: Linguagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var linguagem = await _context.Linguagens.FindAsync(id);
            _context.Linguagens.Remove(linguagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinguagemExists(int id)
        {
            return _context.Linguagens.Any(e => e.Id == id);
        }
    }
}
