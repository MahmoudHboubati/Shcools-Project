using System;
using System.ComponentModel.DataAnnotations;

namespace vega.Controllers.Resources
{
    public class StudentRegistrationResource
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }

        public int StudentId { get; set; }
        public int RegistrationYearId { get; set; }
        public int GradeId { get; set; }
    }
}