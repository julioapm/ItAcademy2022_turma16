using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoEFEngReversaMvc.Models;

namespace DemoEFEngReversaMvc.Controllers
{
    public class CidadesController : Controller
    {
        private readonly CadastroContext _context;

        public CidadesController(CadastroContext context)
        {
            _context = context;
        }

        // GET: Cidades
        public async Task<IActionResult> Index()
        {
            var cadastroContext = _context.Cidades.Include(c => c.UfNavigation);
            return View(await cadastroContext.ToListAsync());
        }

        // GET: Cidades/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Cidades == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades
                .Include(c => c.UfNavigation)
                .FirstOrDefaultAsync(m => m.CodCidade == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // GET: Cidades/Create
        public IActionResult Create()
        {
            ViewData["Uf"] = new SelectList(_context.Estados, "Uf", "Uf");
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodCidade,Nome,Uf")] Cidade cidade)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(cidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["Uf"] = new SelectList(_context.Estados, "Uf", "Uf", cidade.Uf);
            //return View(cidade);
        }

        // GET: Cidades/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Cidades == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }
            ViewData["Uf"] = new SelectList(_context.Estados, "Uf", "Uf", cidade.Uf);
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("CodCidade,Nome,Uf")] Cidade cidade)
        {
            if (id != cidade.CodCidade)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CidadeExists(cidade.CodCidade))
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
            ViewData["Uf"] = new SelectList(_context.Estados, "Uf", "Uf", cidade.Uf);
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Cidades == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades
                .Include(c => c.UfNavigation)
                .FirstOrDefaultAsync(m => m.CodCidade == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Cidades == null)
            {
                return Problem("Entity set 'CadastroContext.Cidades'  is null.");
            }
            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade != null)
            {
                _context.Cidades.Remove(cidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CidadeExists(decimal id)
        {
          return (_context.Cidades?.Any(e => e.CodCidade == id)).GetValueOrDefault();
        }
    }
}
