using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    [Route("/api/students")]
    public class StudentsController : MainController
    {

        public StudentsController(VegaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        #region Get
        [HttpGet]
        public async Task<IEnumerable<StudentResource>> Get()
        {
            var students = await context.Students.ToListAsync();
            return mapper.Map<List<Student>, List<StudentResource>>(students);
        }

        [HttpGet]
        [Route("/api/students/class/{classId}")]
        public async Task<IActionResult> GetByClassId(int classId)
        {
            var queryRes =
                from sc in context.StudentClasses
                join cls in context.Classes on sc.ClassId equals cls.Id
                join std in context.Students on sc.StudentId equals std.Id
                where sc.ClassId == classId
                select std;

            var students = await queryRes.ToListAsync();

            var mapped = mapper.Map<List<Student>, List<StudentResource>>(students);

            return Ok(mapped);
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]StudentResource studentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Student student = mapper.Map<Student>(studentResource);
            context.Students.Add(student);

            await context.SaveChangesAsync();
            var result = mapper.Map<StudentResource>(student);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(int id)
        {
            var item = await context.Students.FindAsync(id);

            if (item == null)
                return NotFound();

            context.Remove(item);
            await context.SaveChangesAsync();

            return Ok(id);
        }
    }
}