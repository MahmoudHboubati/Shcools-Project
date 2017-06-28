using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudyingYearId { get; set; }
        public int GradeId { get; set; }
        public string Description { get; set; }

        public ICollection<StudentClass> Students { get; set; }

        public Class()
        {
            Students = new Collection<StudentClass>();
        }
    }
}