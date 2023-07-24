using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetsSite.Models;

namespace PetsSite.Controllers
{
    public class AnimaisModelsController : Controller
    {
        private readonly Contexto _context;

        public AnimaisModelsController(Contexto context)
        {
            _context = context;
        }

        // GET: AnimaisModels
        public async Task<IActionResult> Index()
        {
              return _context.Animais != null ? 
                          View(await _context.Animais.ToListAsync()) :
                          Problem("Entity set 'Contexto.Animais'  is null.");
        }

        // GET: AnimaisModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Animais == null)
            {
                return NotFound();
            }

            var animaisModel = await _context.Animais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animaisModel == null)
            {
                return NotFound();
            }

            return View(animaisModel);
        }

        // GET: AnimaisModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnimaisModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,animal,raca")] AnimaisModel animaisModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animaisModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animaisModel);
        }

        // GET: AnimaisModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Animais == null)
            {
                return NotFound();
            }

            var animaisModel = await _context.Animais.FindAsync(id);
            if (animaisModel == null)
            {
                return NotFound();
            }
            return View(animaisModel);
        }

        // POST: AnimaisModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,animal,raca")] AnimaisModel animaisModel)
        {
            if (id != animaisModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animaisModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimaisModelExists(animaisModel.Id))
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
            return View(animaisModel);
        }

        // GET: AnimaisModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Animais == null)
            {
                return NotFound();
            }

            var animaisModel = await _context.Animais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animaisModel == null)
            {
                return NotFound();
            }

            return View(animaisModel);
        }

        // POST: AnimaisModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Animais == null)
            {
                return Problem("Entity set 'Contexto.Animais'  is null.");
            }
            var animaisModel = await _context.Animais.FindAsync(id);
            if (animaisModel != null)
            {
                _context.Animais.Remove(animaisModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimaisModelExists(int id)
        {
          return (_context.Animais?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
