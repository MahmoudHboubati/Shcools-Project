using System;

namespace vega.Controllers.Resources
{
    public class ExamResource : Resource
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int SemesterId { get; set; }
        public int ClassId { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }

        public SemesterResource Semester { get; set; }
        public MaterialResource Material { get; set; }
        public ClassResource Class { get; set; }
    }
}