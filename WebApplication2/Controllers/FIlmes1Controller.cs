using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class FIlmes1Controller : Controller
    {
        private readonly WebApplication2Context _context;

        public FIlmes1Controller(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: FIlmes1
        public async Task<IActionResult> Index()
        {
            return View(await _context.FIlme.ToListAsync());
        }

        // GET: FIlmes1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fIlme = await _context.FIlme
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fIlme == null)
            {
                return NotFound();
            }

            return View(fIlme);
        }

        // GET: FIlmes1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FIlmes1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,DataLancamento,Genero,Valor,Avaliacao")] FIlme fIlme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fIlme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fIlme);
        }

        // GET: FIlmes1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fIlme = await _context.FIlme.FindAsync(id);
            if (fIlme == null)
            {
                return NotFound();
            }
            return View(fIlme);
        }

        // POST: FIlmes1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,DataLancamento,Genero,Valor,Avaliacao")] FIlme fIlme)
        {
            if (id != fIlme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fIlme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FIlmeExists(fIlme.Id))
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
            return View(fIlme);
        }

        // GET: FIlmes1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fIlme = await _context.FIlme
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fIlme == null)
            {
                return NotFound();
            }

            return View(fIlme);
        }

        // POST: FIlmes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fIlme = await _context.FIlme.FindAsync(id);
            _context.FIlme.Remove(fIlme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FIlmeExists(int id)
        {
            return _context.FIlme.Any(e => e.Id == id);
        }
    }
}
