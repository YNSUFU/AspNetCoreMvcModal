using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TutoAspNetCoreMvc.Models;

namespace TutoAspNetCoreMvc.Controllers
{
    public class PaysController : Controller
    {
        private readonly testContext _context;

        public PaysController(testContext context)
        {
            _context = context;
        }

        // GET: Pays
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pays.ToListAsync());
        }

        // GET: Pays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pays = await _context.Pays
                .FirstOrDefaultAsync(m => m.IdPays == id);
            if (pays == null)
            {
                return NotFound();
            }
            ViewData["Info"] = "Detail Pays";
            return PartialView(pays);
        }

        // GET: Pays/Create
        public IActionResult Create()
        {
            ViewData["Info"] = "Créer Pays";
            return View();
        }

        // POST: Pays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPays,NomPays")] Pays pays)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pays);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pays);
        }

        // GET: Pays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pays = await _context.Pays.FindAsync(id);
            if (pays == null)
            {
                return NotFound();
            }
            ViewData["Info"] = "Modifier Pays";
            return View(pays);
        }

        // POST: Pays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPays,NomPays")] Pays pays)
        {
            if (id != pays.IdPays)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pays);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaysExists(pays.IdPays))
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
            return View(pays);
        }

        // GET: Pays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pays = await _context.Pays
                .FirstOrDefaultAsync(m => m.IdPays == id);
            if (pays == null)
            {
                return NotFound();
            }
            ViewData["Info"] = "Supprimer Pays";
            return View(pays);
        }

        // POST: Pays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pays = await _context.Pays.FindAsync(id);
            _context.Pays.Remove(pays);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaysExists(int id)
        {
            return _context.Pays.Any(e => e.IdPays == id);
        }
    }
}
