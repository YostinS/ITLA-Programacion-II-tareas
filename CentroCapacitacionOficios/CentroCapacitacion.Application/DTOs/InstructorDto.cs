namespace CentroCapacitacionOficios.Application.DTOs
{
    public class InstructorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Email { get; set; }
        public ICollection<CourseDto> Courses { get; set; }
    }
}
