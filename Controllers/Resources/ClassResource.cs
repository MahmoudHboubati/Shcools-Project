using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.Controllers.Resources
{
    public class ClassResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudyingYearId { get; set; }
        public int GradeId { get; set; }
        public string Description { get; set; }

        public ICollection<int> Students { get; set; }

        public ClassResource()
        {
            Students = new Collection<int>();
        }
    }
}