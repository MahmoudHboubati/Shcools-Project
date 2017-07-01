using System;

namespace vega.Models
{
    public class Exam : Entity
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int SemesterId { get; set; }
        public int ClassId { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; } //hours

        public Semester Semester { get; set; }
        public Material Material { get; set; }
        public Class Class { get; set; }
    }
}