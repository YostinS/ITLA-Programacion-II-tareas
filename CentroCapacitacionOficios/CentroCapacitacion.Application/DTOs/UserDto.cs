using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CentroCapacitacionOficios.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<CertificateDto> Certificates { get; set; }
        public required string Password { get; set; }
    }
}
