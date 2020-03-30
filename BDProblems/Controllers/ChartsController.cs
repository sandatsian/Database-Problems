using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDProblems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly BDProblemsContext _context;

        public ChartsController(BDProblemsContext context)
        {
            _context = context;
        }

        [HttpGet("JsonDataSources")]
        public JsonResult JsonDataSources()
        {
            var sources = _context.Source.Include(p => p.Problem).ToList();
            List<object> sourceProblem = new List<object>();
            sourceProblem.Add(new[] { "Source", "Number of problems" });
            foreach (var t in sources)
            {
                sourceProblem.Add(new object[] { t.SourceName, t.Problem.Count() });
            }
            return new JsonResult(sourceProblem);
        }

        [HttpGet("JsonDataLevels")]
        public JsonResult JsonDataLevels()
        {
            var levels = _context.Level.Include(p => p.Problem).ToList();
            List<object> levelProblem = new List<object>();
            levelProblem.Add(new[] { "Level", "Number of problems" });
            foreach (var item in levels)
            {
                levelProblem.Add(new object[] { item.Name, item.Problem.Count() });
            }
            return new JsonResult(levelProblem);
        }
    }
}