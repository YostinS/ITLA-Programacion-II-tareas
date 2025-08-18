namespace CentroCapacitacionOficios.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationHours { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<Video> Videos { get; set; }
    }

}
