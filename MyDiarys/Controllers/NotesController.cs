using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDiary.Business.Services;

namespace MyDiarys.Controllers
{
    public class NotesController : Controller
    {
        private readonly NoteService _noteContext;
        public NotesController(NoteService noteContext)
        {
            _noteContext = noteContext;
        }
        // GET: Notes
        public async Task <ActionResult> Index()
        {

            var result = await _noteContext.Read();
            return View(result);
        }

        // GET: Notes/Details/5
        public async Task<ActionResult> Details(int Id)
        {
            var noteDetail = await _noteContext.Read();
            if (noteDetail == null)
            {
                return NotFound();
            }
             
            return View(noteDetail);
        }

        // GET: Notes/Create
        public async Task <ActionResult> Create()
        {
            var createnote = await _noteContext.Read();
            return View(createnote);
        }

        // POST: Notes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Notes/Edit/5
        public async Task <ActionResult> Edit(int Id)
        {
            var noteEdit = await _noteContext.Read();
            if (noteEdit == null)
            {
                return NotFound();
            }
           

            return View(noteEdit);
        }

        // POST: Notes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Notes/Delete/5
        public async Task <ActionResult> Delete(int Id)
        {
            var noteDel = await _noteContext.Read();
            if (noteDel != null)
            {
                 
            }
            return View();
        }

        // POST: Notes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}