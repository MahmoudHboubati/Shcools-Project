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
        public DbSet<Class> Classes { get; internal set; }
        public DbSet<StudentClass> StudentClasses { get; internal set; }
        public DbSet<Material> Materials { get; internal set; }
        public DbSet<Semester> Semesters { get; internal set; }
        public DbSet<Exam> Exams { get; internal set; }
    }
}