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
    }
}