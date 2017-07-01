using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    [Route("/api/exam")]
    public class ExamController : MainController
    {
        public ExamController(VegaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allItems = await context.Exams.ToListAsync();
            return Ok(mapper.Map<List<Exam>, List<ExamResource>>(allItems));
        }
        [HttpGet]
        [Route("/api/exam/getListIncludeAll")]
        public async Task<IActionResult> GetListIncludeAll()
        {
            var allItems = await context.Exams
                .Include(e => e.Class)
                .Include(e => e.Material)
                .Include(e => e.Semester)
                .ToListAsync();
            return Ok(mapper.Map<List<Exam>, List<ExamResource>>(allItems));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ExamResource Exam)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Exam newItem = mapper.Map<Exam>(Exam);
            context.Exams.Add(newItem);

            await context.SaveChangesAsync();
            var result = mapper.Map<ExamResource>(newItem);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(int id)
        {
            var item = await context.Exams.FindAsync(id);

            if (item == null)
                return NotFound();

            context.Remove(item);
            await context.SaveChangesAsync();

            return Ok(id);
        }
    }
}