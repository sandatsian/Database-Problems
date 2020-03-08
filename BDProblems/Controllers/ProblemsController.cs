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
    public class ProblemsController : Controller
    {
        private readonly BDProblemsContext _context;


        public ProblemsController(BDProblemsContext context)
        {
            _context = context;
        }

        // GET: Problems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Problem.ToListAsync());
        }

        // GET: Problems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var problemsThemes = _context.ProblemTheme.Where(p => p.ProblemId == id);
            var themes = from t in _context.Theme
                         join pt in problemsThemes on t.Id equals pt.ThemeId
                         select t;

            var problem = await _context.Problem
                .Include(p => p.Level)
                .Include(p => p.Source)
                
                .FirstOrDefaultAsync(m => m.Id == id);

            
            if (problem == null)
            {
                return NotFound();
            }
            ViewBag.Id = problem.Id;
            return View(problem);
            
        }

        // GET: Problems/Create
        public IActionResult Create(int? themeId)
        {
            ViewBag.ThemeId = themeId;
            ViewBag.LevelId = new SelectList(_context.Level, "Id", "Name");
            ViewBag.SourceId = new SelectList(_context.Source, "Id", "SourceName");
            return View();
        }

        // POST: Problems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? themeId, [Bind("Solution,Statement,LevelId,SourceId")] Problem problem)
        {
            problem.Level = _context.Level.Where(l => l.Id == problem.LevelId).FirstOrDefault();
            problem.Source = _context.Source.Where(s => s.Id == problem.SourceId).FirstOrDefault();
            if (_context.Problem.Count().Equals(0))  problem.Id = 0;
            else problem.Id = _context.Problem.Max(pt => pt.Id) + 1;

            if (themeId != null)
            {
                int ptId = 0;
                if (!_context.ProblemTheme.Count().Equals(0))
                    ptId = _context.ProblemTheme.Max(pt => pt.Id) + 1;
                problem.ProblemTheme.Add(new ProblemTheme { Id = ptId, ThemeId = themeId, ProblemId = problem.Id });
            }
          
            
            if (ModelState.IsValid)
            {
                    _context.Add(problem);
                
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Themes");
                //return RedirectToAction("Index", "Problems", new { id = themeId, name = _context.Theme.Where(t => t.Id == themeId).FirstOrDefault().ThemeName });  
            }
            return RedirectToAction("Index", "Themes");
        }

        // GET: Problems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem = await _context.Problem.FindAsync(id);
            if (problem == null)
            {
                return NotFound();
            }
            ViewBag.LevelId = new SelectList(_context.Level, "Id", "Name", problem.LevelId);
            ViewBag.SourceId = new SelectList(_context.Source, "Id", "SourceName", problem.SourceId);
            return View(problem);
        }

        // POST: Problems/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Solution,Statement,LevelId,SourceId")] Problem problem)
        {
            if (id != problem.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(problem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProblemExists(problem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction("Index", "Problems", new { id = levelId, name = _context.Level.Where(l => l.Id == levelId).FirstOrDefault().LevelName });
                return RedirectToAction("Index", "Themes");
            }
            //ViewData["LevelId"] = new SelectList(_context.Level, "Id", "Name", problem.LevelId);
            //ViewData["SourceId"] = new SelectList(_context.Source, "Id", "SourceName", problem.SourceId);
            //return View(problem);
            return RedirectToAction("Index", "Themes");
        }

        // GET: Problems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem = await _context.Problem
                .Include(p => p.Level)
                .Include(p => p.Source)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (problem == null)
            {
                return NotFound();
            }

            return View(problem);
           ;
        }

        // POST: Problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var problem = await _context.Problem.FindAsync(id);
            _context.Problem.Remove(problem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Themes");
        }

        private bool ProblemExists(int id)
        {
            return _context.Problem.Any(e => e.Id == id);
        }
    }
}
