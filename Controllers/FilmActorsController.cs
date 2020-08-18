using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SHAKILA.Models;

namespace SHAKILA.Controllers
{
    public class FilmActorsController : Controller
    {
        private readonly SakilaContext _context;

        public FilmActorsController(SakilaContext context)
        {
            _context = context;
        }

        // GET: FilmActors
        public async Task<IActionResult> Index()
        {
            return View(await _context.FilmActor.ToListAsync());
        }

        // GET: FilmActors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmActor = await _context.FilmActor
                .FirstOrDefaultAsync(m => m.ActorId == id);
            if (filmActor == null)
            {
                return NotFound();
            }

            return View(filmActor);
        }

        // GET: FilmActors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmActors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActorId,FilmId,LastUpdate")] FilmActor filmActor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmActor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmActor);
        }

        // GET: FilmActors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmActor = await _context.FilmActor.FindAsync(id);
            if (filmActor == null)
            {
                return NotFound();
            }
            return View(filmActor);
        }

        // POST: FilmActors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActorId,FilmId,LastUpdate")] FilmActor filmActor)
        {
            if (id != filmActor.ActorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmActor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmActorExists(filmActor.ActorId))
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
            return View(filmActor);
        }

        // GET: FilmActors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmActor = await _context.FilmActor
                .FirstOrDefaultAsync(m => m.ActorId == id);
            if (filmActor == null)
            {
                return NotFound();
            }

            return View(filmActor);
        }

        // POST: FilmActors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmActor = await _context.FilmActor.FindAsync(id);
            _context.FilmActor.Remove(filmActor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmActorExists(int id)
        {
            return _context.FilmActor.Any(e => e.ActorId == id);
        }
    }
}
