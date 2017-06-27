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
    [Route("api/StudyingYear")]
    public class StudyingYearController : LookupController
    {
        public StudyingYearController(VegaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<StudyingYearResource>> Get()
        {
            var allItems = await context.StudyingYears.ToListAsync();
            return mapper.Map<List<StudyingYear>, List<StudyingYearResource>>(allItems);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]StudyingYearResource studentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StudyingYear newItem = mapper.Map<StudyingYear>(studentResource);
            context.StudyingYears.Add(newItem);

            await context.SaveChangesAsync();
            var result = mapper.Map<StudyingYearResource>(newItem);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(int id)
        {
            var item = await context.StudyingYears.FindAsync(id);

            if (item == null)
                return NotFound();

            context.Remove(item);
            await context.SaveChangesAsync();

            return Ok(id);
        }
    }
}