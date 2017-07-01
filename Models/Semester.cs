namespace vega.Models
{
    public class Semester : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StudyingYearId { get; set; }
        public StudyingYear StudyingYear { get; set; }
    }
}