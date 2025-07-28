namespace CentroCapacitacionOficios_FinalProject_Prog2.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationHours { get; set; }
        public int InstructorId { get; set; }
    }
}
