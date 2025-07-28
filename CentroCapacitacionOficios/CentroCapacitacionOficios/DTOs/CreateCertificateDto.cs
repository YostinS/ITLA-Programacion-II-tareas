namespace CentroCapacitacionOficios.DTOs
{
    public class CreateCertificateDto
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime IssuedDate { get; set; }
        // Constructor to initialize the IssuedDate to the current date
        public CreateCertificateDto()
        {
            IssuedDate = DateTime.Now;
        }
    }
}
