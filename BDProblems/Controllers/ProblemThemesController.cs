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
    public class ProblemThemesController : Controller
    {
        private readonly BDProblemsContext _context;

        public ProblemThemesController(BDProblemsContext context)
        {
            _context = context;
        }

        // GET: ProblemThemes
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.ProblemId = id;
            var bDProblemsContext = _context.ProblemTheme.Where(p => p.ProblemId == id).Include(p => p.Theme);
            return View(await bDProblemsContext.ToListAsync());
        }

        // GET: ProblemThemes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problemTheme = await _context.ProblemTheme
                .Include(p => p.Problem)
                .Include(p => p.Theme)
                .FirstOrDefaultAsync(m => m.ProblemId == id);
            if (problemTheme == null)
            {
                return NotFound();
            }

            return View(problemTheme);
        }

        // GET: ProblemThemes/Create
        public IActionResult Create(int? id)
        {
            List<int?> theme = _context.ProblemTheme.Where(p => p.ProblemId == id).Select(t => t.ThemeId).ToList();
            ViewBag.ProblemId = id;
            ViewData["ThemeId"] = new SelectList(_context.Theme.Where(t => theme.Contains(t.Id) == false), "Id", "ThemeName");
            return View();
        }

        // POST: ProblemThemes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, [Bind("ProblemId,ThemeId")] ProblemTheme problemTheme)
        {
            if (id == null)
            {
                return NotFound();
            }
            int ptId = 0;
            if (_context.ProblemTheme.Count() != 0)
            {
                ptId = _context.ProblemTheme.Max(p => p.Id) + 1;
            }
            problemTheme.Id = ptId;
            problemTheme.ProblemId = id;
            problemTheme.Problem = _context.Problem.Where(p => p.Id == id).FirstOrDefault();
            problemTheme.Theme = _context.Theme.Where(t => t.Id == problemTheme.ThemeId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                _context.Add(problemTheme);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ProblemThemes", new { id = problemTheme.ProblemId });
            }
            //ViewData["ProblemId"] = new SelectList(_context.Problem, "Id", "Id", problemTheme.ProblemId);
            //ViewData["ThemeId"] = new SelectList(_context.Theme, "Id", "ThemeName", problemTheme.ThemeId);
            return RedirectToAction("Index", "ProblemThemes", new { id = problemTheme.ProblemId });
        }

        // GET: ProblemThemes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problemTheme = await _context.ProblemTheme.FindAsync(id);
            if (problemTheme == null)
            {
                return NotFound();
            }
            ViewData["ProblemId"] = new SelectList(_context.Problem, "Id", "Id", problemTheme.ProblemId);
            ViewData["ThemeId"] = new SelectList(_context.Theme, "Id", "ThemeName", problemTheme.ThemeId);
            return View(problemTheme);
        }

        // POST: ProblemThemes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,ProblemId,ThemeId")] ProblemTheme problemTheme)
        {
            if (id != problemTheme.ProblemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(problemTheme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProblemThemeExists(problemTheme.ProblemId))
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
            ViewData["ProblemId"] = new SelectList(_context.Problem, "Id", "Id", problemTheme.ProblemId);
            ViewData["ThemeId"] = new SelectList(_context.Theme, "Id", "ThemeName", problemTheme.ThemeId);
            return View(problemTheme);
        }

        // GET: ProblemThemes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problemTheme = await _context.ProblemTheme
                .Include(p => p.Problem)
                .Include(p => p.Theme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (problemTheme == null)
            {
                return NotFound();
            }
            return View(problemTheme);
        }

        // POST: ProblemThemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            ProblemTheme p = _context.ProblemTheme.Where(p => p.Id == id).FirstOrDefault();
            int? pId = p.ProblemId;
            int? tId = p.ThemeId;
            var problemTheme = await _context.ProblemTheme.FindAsync(pId, tId);

            _context.ProblemTheme.Remove(problemTheme);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Problems", new { id = pId });
        }

        private bool ProblemThemeExists(int? id)
        {
            return _context.ProblemTheme.Any(e => e.ProblemId == id);
        }
    }
}
