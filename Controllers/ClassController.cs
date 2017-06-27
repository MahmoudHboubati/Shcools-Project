using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Models;
using vega.Persistence;
using vega.Controllers.Resources;

namespace vega.Controllers
{
    [Route("/api/class")]
    public class ClassController : MainController
    {
        public ClassController(VegaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<ClassResource>> Get()
        {
            var studRegs = await context.Classes.ToListAsync();
            return mapper.Map<List<Class>, List<ClassResource>>(studRegs);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ClassResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Class studentReg = mapper.Map<Class>(resource);
            context.Classes.Add(studentReg);

            await context.SaveChangesAsync();
            var result = mapper.Map<ClassResource>(studentReg);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(int id)
        {
            var item = await context.Classes.FindAsync(id);

            if (item == null)
                return NotFound();

            context.Remove(item);
            await context.SaveChangesAsync();

            return Ok(id);
        }
    }
}