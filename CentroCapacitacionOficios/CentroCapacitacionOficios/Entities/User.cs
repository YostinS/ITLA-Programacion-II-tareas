namespace CentroCapacitacionOficios.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
    }
}
