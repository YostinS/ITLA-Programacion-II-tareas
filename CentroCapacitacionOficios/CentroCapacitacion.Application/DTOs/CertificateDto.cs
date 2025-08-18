namespace CentroCapacitacionOficios.Application.DTOs
{
    public class CertificateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int CourseId { get; set; }
        public CourseDto Course { get; set; }
        public DateTime IssuedDate { get; set; }
    }
}
