namespace CentroCapacitacionOficios.Application.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationHours { get; set; }
        public int InstructorId { get; set; }
        public InstructorDto Instructor { get; set; }
        public ICollection<CertificateDto> Certificates { get; set; }
        public ICollection<VideoDto> Videos { get; set; }
    }

}
