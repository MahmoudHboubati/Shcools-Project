using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Lookups;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers.Lookups
{

    [Route("/api/material")]
    public class MaterialController : LookupController
    {
        public MaterialController(VegaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allItems = await context.Materials.ToListAsync();
            return Ok(mapper.Map<List<Material>, List<MaterialResource>>(allItems));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MaterialResource material)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Material newItem = mapper.Map<Material>(material);
            context.Materials.Add(newItem);

            await context.SaveChangesAsync();
            var result = mapper.Map<MaterialResource>(newItem);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(int id)
        {
            var item = await context.Materials.FindAsync(id);

            if (item == null)
                return NotFound();

            context.Remove(item);
            await context.SaveChangesAsync();

            return Ok(id);
        }
    }
}