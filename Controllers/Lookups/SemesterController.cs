using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers.Lookups
{
    [Route("/api/Semester")]
    public class SemesterController : LookupController
    {
        public SemesterController(VegaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allItems = await context.Semesters.Include(s => s.StudyingYear).ToListAsync();
            return Ok(mapper.Map<List<Semester>, List<SemesterResource>>(allItems));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SemesterResource semester)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Semester newItem = mapper.Map<Semester>(semester);
            context.Semesters.Add(newItem);

            await context.SaveChangesAsync();
            var result = mapper.Map<SemesterResource>(newItem);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(int id)
        {
            var item = await context.Semesters.FindAsync(id);

            if (item == null)
                return NotFound();

            context.Remove(item);
            await context.SaveChangesAsync();

            return Ok(id);
        }
    }
}