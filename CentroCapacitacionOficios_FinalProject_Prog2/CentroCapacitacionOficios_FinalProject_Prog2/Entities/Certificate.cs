namespace CentroCapacitacionOficios_FinalProject_Prog2.Entities
{
    public class Certificate
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime IssuedDate { get; set; }
    }
}
