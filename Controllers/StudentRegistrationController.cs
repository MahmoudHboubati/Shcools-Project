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
    [Route("/api/studentRegistration")]
    public class StudentRegistrationController : MainController
    {
        public StudentRegistrationController(VegaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<StudentRegistrationResource>> Get()
        {
            var studRegs = await context.StudentRegistrations.ToListAsync();
            return mapper.Map<List<StudentRegistration>, List<StudentRegistrationResource>>(studRegs);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]StudentRegistrationResource studentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StudentRegistration studentReg = mapper.Map<StudentRegistration>(studentResource);
            context.StudentRegistrations.Add(studentReg);

            await context.SaveChangesAsync();
            var result = mapper.Map<StudentRegistrationResource>(studentReg);
            return Ok(result);
        }
    }
}