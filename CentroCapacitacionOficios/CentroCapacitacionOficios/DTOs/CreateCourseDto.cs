namespace CentroCapacitacionOficios.DTOs
{
    public class CreateCourseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationHours { get; set; }
        public int InstructorId { get; set; }
        public int CertificateId { get; set; }
    }
}
