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
    public class ThemesController : Controller
    {
        private readonly BDProblemsContext _context;

        public ThemesController(BDProblemsContext context)
        {
            _context = context;
        }

        // GET: Themes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Theme.ToListAsync());
        }

        // GET: Themes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return RedirectToAction("Themes", "Index");
            ViewBag.ThemeId = id;
            ViewBag.ThemeName = _context.Theme.Where(t => t.Id == id).FirstOrDefault().ThemeName;
            var problems = _context.Problem;
            var problemsThemes = _context.ProblemTheme.Where(p => p.ThemeId == id);
            var bDProblemsContext = from p in problems
                                    join pt in problemsThemes on p.Id equals pt.ProblemId
                                    select p;

            return View(await bDProblemsContext.ToListAsync());
        }


        // GET: Themes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Themes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThemeName")] Theme theme)
        {
            foreach(var item in _context.Theme)
            {
                if (item.ThemeName == theme.ThemeName)
                    return RedirectToAction("Index");
            }
            
            if (_context.Theme.Count().Equals(0)) theme.Id = 0;
            else theme.Id = _context.Theme.Max(pt => pt.Id) + 1;
            if (ModelState.IsValid)
            {
                _context.Theme.Add(theme);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(theme);
        }

        // GET: Themes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theme = await _context.Theme.FindAsync(id);
            if (theme == null)
            {
                return NotFound();
            }
            return View(theme);
        }

        // POST: Themes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ThemeName")] Theme theme)
        {
            if (id != theme.Id)
            {
                return NotFound();
            }
            foreach (var item in _context.Theme)
            {
                if (item.ThemeName == theme.ThemeName)
                    return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThemeExists(theme.Id))
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
            return View(theme);
        }

        // GET: Themes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theme = await _context.Theme
                .FirstOrDefaultAsync(m => m.Id == id);
            if (theme == null)
            {
                return NotFound();
            }

            return View(theme);
        }

        // POST: Themes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var theme = await _context.Theme.FindAsync(id);
            _context.Theme.Remove(theme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThemeExists(int id)
        {
            return _context.Theme.Any(e => e.Id == id);
        }
    }
}
