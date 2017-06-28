using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    //Todo: to remove this controller since functionality here can be acheaved by student controller
    [Route("/api/StudentClass")]
    public class StudentClassController : MainController
    {
        public StudentClassController(VegaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<StudentClassResource>> Get()
        {
            var item = await context.StudentClasses.ToListAsync();
            return mapper.Map<List<StudentClass>, List<StudentClassResource>>(item);
        }
        [HttpGet()]
        [Route("/api/StudentClass/class/{classId}")]
        public async Task<IActionResult> GetByClassId(int classId)
        {
            var items = await context.StudentClasses.Where(s => s.ClassId == classId).ToListAsync();
            var res = mapper.Map<List<StudentClass>, List<StudentClassResource>>(items);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]StudentClassResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StudentClass studentClass = mapper.Map<StudentClass>(resource);
            context.StudentClasses.Add(studentClass);

            await context.SaveChangesAsync();
            var result = mapper.Map<StudentClassResource>(studentClass);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(int id)
        {
            var item = await context.StudentClasses.FindAsync(id);

            if (item == null)
                return NotFound();

            context.Remove(item);
            await context.SaveChangesAsync();

            return Ok(id);
        }


    }
}