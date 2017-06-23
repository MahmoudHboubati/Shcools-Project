using System;
using System.ComponentModel.DataAnnotations;

namespace vega.Controllers.Resources
{
    public class StudentResource
    {
        [Required]
        public string Name { get; set; }
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}