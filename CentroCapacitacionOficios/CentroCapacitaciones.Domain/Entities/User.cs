using System.ComponentModel.DataAnnotations;

namespace CentroCapacitacionOficios.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
    }
}
