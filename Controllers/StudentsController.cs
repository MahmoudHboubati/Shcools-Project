using System.Collections.Generic;
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
    public class StudentsController : BaseController
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public StudentsController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/students")]
        public async Task<IEnumerable<StudentResource>> Get()
        {
            var students = await context.Students.ToListAsync();
            return mapper.Map<List<Student>, List<StudentResource>>(students);
        }

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
    }
}