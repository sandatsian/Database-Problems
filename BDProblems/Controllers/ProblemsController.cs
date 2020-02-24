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
        public async Task<IActionResult> Index(int? id, string? name)
        {
            if (id == null) return RedirectToAction("Themes", "Index");
            ViewBag.ThemeId = id;
            ViewBag.ThemeName = name;
            var problems = _context.Problem;
            var problemsThemes = _context.ProblemTheme.Where(p => p.ThemeId == id);
            var bDProblemsContext = from p in problems
                                    join pt in problemsThemes on p.Id equals pt.ProblemId
                                    select p;
            
            return View(await bDProblemsContext.ToListAsync());
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

            return View(problem);
            
        }

        // GET: Problems/Create
        public IActionResult Create()
        {
            ViewBag.Level = new SelectList(_context.Level, "Id", "Name");
            //ViewBag.LevelName = _context.Level.Where(l => l.Id == levelId).FirstOrDefault().Name;
            ViewBag.Source = new SelectList( _context.Source, "Id", "SourceName");
            ViewBag.Themes = new SelectList(_context.Theme, "Id", "ThemeName");
            ViewBag.Grades = new SelectList(_context.Grade, "Id", "GradeName");
           
            //ViewData["SourceId"] = new SelectList(_context.Source, "Id", "Source1");
            return View();
        }

        // POST: Problems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ICollection<ProblemGrade> ProblemGrade, ICollection<ProblemTheme> ProblemTheme, [Bind("Solution,Statement,LevelId,SourceId")] Problem problem)
        {
            using(_context.Database.BeginTransaction())
            problem.ProblemTheme = ProblemTheme;
            problem.ProblemGrade = ProblemGrade;

            if (ModelState.IsValid)
            {
                _context.Add(problem);
                
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Themes");
                //return RedirectToAction("Index", "Problems", new { id = themeId, name = _context.Theme.Where(t => t.Id == themeId).FirstOrDefault().ThemeName });  
            }
            return RedirectToAction("Index", "Themes");
           //ViewData["LevelId"] = new SelectList(_context.Level, "Id", "LevelName", problem.LevelId);
            //ViewData["SourceId"] = new SelectList(_context.Source, "Id", "Id", problem.SourceId);
            //return View(problem);
            //return RedirectToAction("Index", "Problems", new { id = themeId, name = _context.Theme.Where(t => t.Id == themeId).FirstOrDefault().ThemeName });
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
            ViewData["LevelId"] = new SelectList(_context.Level, "Id", "LevelName", problem.LevelId);
            ViewData["SourceId"] = new SelectList(_context.Source, "Id", "Id", problem.SourceId);
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
                return View();
            }
            ViewData["LevelId"] = new SelectList(_context.Level, "Id", "LevelName", problem.LevelId);
            ViewData["SourceId"] = new SelectList(_context.Source, "Id", "Id", problem.SourceId);
            //return View(problem);
            return RedirectToAction("Index" );//, "Problems", new { id = problem.LevelId, name = problem.LevelId });
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
