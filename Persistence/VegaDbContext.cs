using Microsoft.EntityFrameworkCore;
using vega.Models;

namespace vega.Persistence
{
    public class VegaDbContext : DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options)
          : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentRegistration> StudentRegistrations { get; set; }
        public DbSet<RegistrationYear> RegistrationYears { get; set; }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<StudyingYear> StudyingYears { get; set; }
    }
}