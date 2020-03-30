using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDProblems;

namespace BDProblems.Controllers
{
    public class SourcesController : Controller
    {
        private readonly BDProblemsContext _context;

        public SourcesController(BDProblemsContext context)
        {
            _context = context;
        }

        // GET: Sources
        public async Task<IActionResult> Index()
        {
            return View(await _context.Source.ToListAsync());
        }

        // GET: Sources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return RedirectToAction("Sources", "Index");
            ViewBag.SourceId = id;
            ViewBag.SourceName = _context.Source.Where(t => t.Id == id).FirstOrDefault().SourceName;
            ViewBag.SourceInfo = _context.Source.Where(t => t.Id == id).FirstOrDefault().Info;

            var bDProblemsContext = _context.Problem.Where(p => p.SourceId == id);

            return View(await bDProblemsContext.ToListAsync());
        }

        // GET: Sources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SourceName,Info")] Source source)
        {
            foreach (var item in _context.Source)
            {
                if (item.SourceName == source.SourceName)
                    return RedirectToAction("Index");
            }
            if (_context.Source.Count().Equals(0)) source.Id = 0;
            else source.Id = _context.Source.Max(pt => pt.Id) + 1;
            if (ModelState.IsValid)
            {
                _context.Add(source);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(source);
        }

        // GET: Sources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var source = await _context.Source.FindAsync(id);
            if (source == null)
            {
                return NotFound();
            }
            return View(source);
        }

        // POST: Sources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SourceName,Info")] Source source)
        {
            foreach (var item in _context.Source)
            {
                if (item.SourceName == source.SourceName)
                    return RedirectToAction("Index");
            }
            if (id != source.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(source);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SourceExists(source.Id))
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
            return View(source);
        }

        // GET: Sources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var source = await _context.Source
                .FirstOrDefaultAsync(m => m.Id == id);
            if (source == null)
            {
                return NotFound();
            }

            return View(source);
        }

        // POST: Sources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var source = await _context.Source.FindAsync(id);
            _context.Source.Remove(source);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SourceExists(int id)
        {
            return _context.Source.Any(e => e.Id == id);
        }
    }
}
