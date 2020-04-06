using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore;
using BDProblems;
using Microsoft.AspNetCore.Http;
using ClosedXML.Excel;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace BDProblems.Controllers
{
    [Authorize(Roles = "admin, user")]
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
            int i = 0;
            HashSet<char> setBig = new HashSet<char>();
            for (i = 192; i < 224; i++)
            {
                setBig.Add((char)i);
            }
            setBig.Add((char)175);
            setBig.Add((char)178);

            HashSet<char> setSmall = new HashSet<char>();
            for (i = 224; i < 256; i++)
            {
                setSmall.Add((char)i);
            }
            setSmall.Add((char)180);
            setSmall.Add((char)179);
            setSmall.Add(' ');

            string name = theme.ThemeName;
            string finalName = "";
            i = 0;
            while (name[i] == ' ')
            {
                i++;
            }
            for (int j = i; j < name.Length; j++)
            {
                if (setSmall.Contains(name[i]))
                    finalName.Append((char)(name[i] - 32));
                if (j > i && !setSmall.Contains(name[j]))
                {
                    return RedirectToAction("Index");
                }
            }
            theme.ThemeName = finalName;
            foreach (var item in _context.Theme)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Import(IFormFile fileExcel)
        {
            if (ModelState.IsValid)
            {
                if (fileExcel != null)
                {
                    using (var stream = new System.IO.FileStream(fileExcel.FileName, FileMode.Create))
                    {
                        await fileExcel.CopyToAsync(stream);
                        using (XLWorkbook workBook = new XLWorkbook(stream, XLEventTracking.Disabled))
                        {
                            foreach (IXLWorksheet worksheet in workBook.Worksheets)
                            {
                                /*Theme newTheme;
                                var t = _context.Theme.Where(p => p.ThemeName == worksheet.Name).ToList();
                                //var t = (from theme in _context.Theme
                                //         where theme.ThemeName == worksheet.Name
                                //         select theme).ToList();
                                if(t.Count > 0)
                                {
                                    newTheme = t[0];
                                }
                                else
                                {
                                    newTheme = new Theme();
                                    newTheme.ThemeName = worksheet.Name;
                                    _context.Theme.Add(newTheme);
                                }*/
                                Theme newTheme = new Theme();
                                newTheme.ThemeName = worksheet.Name;
                                foreach (var t in _context.Theme)
                                {
                                    if (t.ThemeName == newTheme.ThemeName)
                                        break;
                                    else
                                        _context.Theme.Add(newTheme);
                                }
                                foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                                {
                                    try
                                    {
                                        Problem problem = new Problem();
                                        problem.Statement = row.Cell(1).Value.ToString();
                                        problem.Solution = row.Cell(2).Value.ToString();
                                        problem.LevelId = (int)_context.Level.Where(p => p.Name == row.Cell(3).Value.ToString()).FirstOrDefault().Id;
                                        problem.SourceId = (int)_context.Source.Where(p => p.SourceName == row.Cell(4).Value.ToString()).FirstOrDefault().Id;
                                        ProblemGrade pg = new ProblemGrade();
                                        pg.ProblemId = problem.Id;
                                        pg.GradeId = (int)_context.Grade.Where(g => g.GradeName == row.Cell(5).Value.ToString()).FirstOrDefault().Id;
                                        _context.ProblemGrade.Add(pg);
                                        ProblemTheme pt = new ProblemTheme();
                                        pt.ProblemId = problem.Id;
                                        pt.ThemeId = (int)_context.Theme.Where(g => g.ThemeName == newTheme.ThemeName).FirstOrDefault().Id;
                                        _context.ProblemTheme.Add(pt);
                                    }
                                    catch (Exception e)
                                    {
                                        return RedirectToAction(nameof(Index));
                                    }
                                }
                            }

                        }
                    }
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Export()
        {
            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var themes = _context.Theme.ToList();
                foreach (var t in themes)
                {
                    var worksheet = workbook.Worksheets.Add(t.ThemeName);
                    worksheet.Cell("A1").Value = "Statement";
                    worksheet.Cell("B1").Value = "Solution";
                    worksheet.Cell("C1").Value = "Level";
                    worksheet.Cell("D1").Value = "Source";
                    worksheet.Cell("E1").Value = "Grade";
                    worksheet.Row(1).Style.Font.Bold = true;
                    var problemsThemes = _context.ProblemTheme.Where(p => p.ThemeId == t.Id);
                    var problems = from p in _context.Problem
                                   join pt in problemsThemes on p.Id equals pt.ProblemId
                                   select p;
                    List<Problem> prob = problems.ToList();

                    for (int i = 0; i < problems.Count(); i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = prob[i].Statement;
                        worksheet.Cell(i + 2, 2).Value = prob[i].Solution;
                        worksheet.Cell(i + 2, 3).Value = _context.Level.Where(p => p.Id == prob[i].LevelId).FirstOrDefault().Name;
                        worksheet.Cell(i + 2, 4).Value = _context.Source.Where(p => p.Id == prob[i].SourceId).FirstOrDefault().SourceName;
                        var grade = _context.ProblemGrade.Where(p => p.ProblemId == prob[i].Id).FirstOrDefault();
                        if (grade != null)
                        {
                            worksheet.Cell(i + 2, 5).Value = grade.GradeId + 1;
                        }

                    }
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();
                    return new FileContentResult(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = $"Problems_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }



            }

        }
    }
}
