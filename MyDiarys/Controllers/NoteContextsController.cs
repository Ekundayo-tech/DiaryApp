using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyDiarys.Models;

namespace MyDiarys.Controllers
{
    public class NoteContextsController : Controller
    {
        private readonly NoteDBContext _context;

        public NoteContextsController(NoteDBContext context)
        {
            _context = context;
        }

        // GET: NoteContexts
        public async Task<IActionResult> Index()
        {
            return View(await _context.noteContexts.ToListAsync());
        }

        // GET: NoteContexts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noteContext = await _context.noteContexts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (noteContext == null)
            {
                return NotFound();
            }

            return View(noteContext);
        }

        // GET: NoteContexts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NoteContexts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,DateCreated,DateModified,Details")] NoteContext noteContext)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noteContext);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noteContext);
        }

        // GET: NoteContexts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noteContext = await _context.noteContexts.FindAsync(id);
            if (noteContext == null)
            {
                return NotFound();
            }
            return View(noteContext);
        }

        // POST: NoteContexts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,DateCreated,DateModified,Details")] NoteContext noteContext)
        {
            if (id != noteContext.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noteContext);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteContextExists(noteContext.ID))
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
            return View(noteContext);
        }

        // GET: NoteContexts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noteContext = await _context.noteContexts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (noteContext == null)
            {
                return NotFound();
            }

            return View(noteContext);
        }

        // POST: NoteContexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noteContext = await _context.noteContexts.FindAsync(id);
            _context.noteContexts.Remove(noteContext);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteContextExists(int id)
        {
            return _context.noteContexts.Any(e => e.ID == id);
        }
    }
}
