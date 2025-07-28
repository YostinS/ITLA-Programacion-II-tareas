namespace CentroCapacitacionOficios.DTOs
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        // Constructor to initialize the RegistrationDate to the current date
        public CreateUserDto()
        {
            RegistrationDate = DateTime.Now;
        }
    }
}
