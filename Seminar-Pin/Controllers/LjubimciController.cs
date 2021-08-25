using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Seminar_Pin.Data;
using Seminar_Pin.Models;

namespace Seminar_Pin.Controllers
{
    public class LjubimciController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LjubimciController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ljubimci
        [Authorize]
        public async Task<IActionResult> Index(string search)
        {
            if(!String.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                var ljubimciSearch = from ljubimci in _context.Ljubimci select ljubimci;
                ljubimciSearch = ljubimciSearch.Where(Ljubimci => Ljubimci.Ime.Contains(search));
                return View(ljubimciSearch.ToList());
            }
            return View(await _context.Ljubimci.ToListAsync());
        }

        // GET: Ljubimci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ljubimci = await _context.Ljubimci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ljubimci == null)
            {
                return NotFound();
            }

            return View(ljubimci);
        }

        // GET: Ljubimci/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ljubimci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Vrsta,DatumRodenja")] Ljubimci ljubimci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ljubimci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ljubimci);
        }

        // GET: Ljubimci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ljubimci = await _context.Ljubimci.FindAsync(id);
            if (ljubimci == null)
            {
                return NotFound();
            }
            return View(ljubimci);
        }

        // POST: Ljubimci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Vrsta,DatumRodenja")] Ljubimci ljubimci)
        {
            if (id != ljubimci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ljubimci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LjubimciExists(ljubimci.Id))
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
            return View(ljubimci);
        }

        // GET: Ljubimci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ljubimci = await _context.Ljubimci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ljubimci == null)
            {
                return NotFound();
            }

            return View(ljubimci);
        }

        // POST: Ljubimci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ljubimci = await _context.Ljubimci.FindAsync(id);
            _context.Ljubimci.Remove(ljubimci);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LjubimciExists(int id)
        {
            return _context.Ljubimci.Any(e => e.Id == id);
        }
    }
}
