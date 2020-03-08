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
    public class ProblemGradesController : Controller
    {
        private readonly BDProblemsContext _context;

        public ProblemGradesController(BDProblemsContext context)
        {
            _context = context;
        }

        // GET: ProblemGrades
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.ProblemId = id;
            var bDProblemsContext = _context.ProblemGrade.Where(p => p.ProblemId == id).Include(p => p.Grade);
            return View(await bDProblemsContext.ToListAsync());
        }

        // GET: ProblemGrades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problemGrade = await _context.ProblemGrade
                .Include(p => p.Grade)
                .Include(p => p.Problem)
                .FirstOrDefaultAsync(m => m.ProblemId == id);
            if (problemGrade == null)
            {
                return NotFound();
            }

            return View(problemGrade);
        }

        // GET: ProblemGrades/Create
        public IActionResult Create(int? id)
        {
            List<int?> grade = _context.ProblemGrade.Where(p => p.ProblemId == id).Select(t => t.GradeId).ToList();
            ViewData["ProblemId"] = id;
            ViewData["GradeId"] = new SelectList(_context.Grade.Where(t => grade.Contains(t.Id) == false), "Id", "GradeName");
            return View();
        }

        // POST: ProblemGrades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, [Bind("ProblemId,GradeId")] ProblemGrade problemGrade)
        {
            if (id == null)
            {
                return NotFound();
            }
            int ptId = 0;
            if (_context.ProblemGrade.Count() != 0)
            {
                ptId = _context.ProblemGrade.Max(p => p.Id) + 1;
            }
            problemGrade.Id = ptId;
            problemGrade.ProblemId = id;
            problemGrade.Problem = _context.Problem.Where(p => p.Id == id).FirstOrDefault();
            problemGrade.Grade = _context.Grade.Where(t => t.Id == problemGrade.GradeId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                _context.ProblemGrade.Add(problemGrade);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ProblemGrades", new { id = problemGrade.ProblemId });
            }
            //ViewData["ProblemId"] = new SelectList(_context.Problem, "Id", "Id", problemTheme.ProblemId);
            //ViewData["ThemeId"] = new SelectList(_context.Theme, "Id", "ThemeName", problemTheme.ThemeId);
            return RedirectToAction("Index", "ProblemGrades", new { id = problemGrade.ProblemId });
        }

        // GET: ProblemGrades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problemGrade = await _context.ProblemGrade.FindAsync(id);
            if (problemGrade == null)
            {
                return NotFound();
            }
            ViewData["GradeId"] = new SelectList(_context.Grade, "Id", "GradeName", problemGrade.GradeId);
            ViewData["ProblemId"] = new SelectList(_context.Problem, "Id", "Id", problemGrade.ProblemId);
            return View(problemGrade);
        }

        // POST: ProblemGrades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,ProblemId,GradeId")] ProblemGrade problemGrade)
        {
            if (id != problemGrade.ProblemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(problemGrade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProblemGradeExists(problemGrade.ProblemId))
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
            ViewData["GradeId"] = new SelectList(_context.Grade, "Id", "GradeName", problemGrade.GradeId);
            ViewData["ProblemId"] = new SelectList(_context.Problem, "Id", "Id", problemGrade.ProblemId);
            return View(problemGrade);
        }

        // GET: ProblemGrades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problemGrade = await _context.ProblemGrade
                .Include(p => p.Grade)
                .Include(p => p.Problem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (problemGrade == null)
            {
                return NotFound();
            }

            return View(problemGrade);
        }

        // POST: ProblemGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            ProblemGrade p = _context.ProblemGrade.Where(p => p.Id == id).FirstOrDefault();
            int? pId = p.ProblemId;
            int? gId = p.GradeId;
            var problemGrade = await _context.ProblemGrade.FindAsync(pId, gId);

            _context.ProblemGrade.Remove(problemGrade);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Problems", new { id = pId });
        }

        private bool ProblemGradeExists(int? id)
        {
            return _context.ProblemGrade.Any(e => e.ProblemId == id);
        }
    }
}
