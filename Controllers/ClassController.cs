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
        #region Get
        [HttpGet]
        public async Task<IEnumerable<ClassResource>> Get()
        {
            var studRegs = await context.Classes.ToListAsync();
            return mapper.Map<List<Class>, List<ClassResource>>(studRegs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var clas = await context.Classes.FindAsync(id);
            return Ok(mapper.Map<Class, ClassResource>(clas));
        }
        [HttpGet("withChilds/{id}")]
        public async Task<IActionResult> GetWithChilds(int id)
        {
            var clas = await context.Classes.Include(c => c.Students).SingleOrDefaultAsync(c => c.Id == id);
            return Ok(mapper.Map<Class, ClassResource>(clas));
        }
        #endregion

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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClassResource classResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var toUpdate = await context.Classes.Include(c => c.Students).SingleOrDefaultAsync(c => c.Id == id);

            if (toUpdate == null)
                return NotFound();

            mapper.Map<ClassResource, Class>(classResource, toUpdate);

            await context.SaveChangesAsync();

            var result = mapper.Map<Class, ClassResource>(toUpdate);

            return Ok(result);
        }
    }
}