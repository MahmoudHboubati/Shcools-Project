namespace vega.Controllers.Resources
{
    public class StudentClassResource
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }

        public ClassResource Class { get; set; }
        public StudentResource Student { get; set; }
    }
}