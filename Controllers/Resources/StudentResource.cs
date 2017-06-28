using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace vega.Controllers.Resources
{
    public class StudentResource
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public ICollection<int> Classes { get; set; }

        public StudentResource()
        {
            Classes = new Collection<int>();
        }
    }
}