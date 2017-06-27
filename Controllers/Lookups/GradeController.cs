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
    [Route("/api/grade")]
    public class GradeController : LookupController
    {
        public GradeController(VegaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<GradeResource>> Get()
        {
            var allItems = await context.Grades.ToListAsync();
            return mapper.Map<List<Grade>, List<GradeResource>>(allItems);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GradeResource studentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Grade newItem = mapper.Map<Grade>(studentResource);
            context.Grades.Add(newItem);

            await context.SaveChangesAsync();
            var result = mapper.Map<GradeResource>(newItem);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(int id)
        {
            var item = await context.Grades.FindAsync(id);

            if (item == null)
                return NotFound();

            context.Remove(item);
            await context.SaveChangesAsync();

            return Ok(id);
        }
    }
}