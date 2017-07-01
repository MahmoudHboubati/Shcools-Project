namespace vega.Controllers.Resources
{
    public class SemesterResource : Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StudyingYearId { get; set; }
        public StudyingYearResource StudyingYear { get; set; }
    }
}