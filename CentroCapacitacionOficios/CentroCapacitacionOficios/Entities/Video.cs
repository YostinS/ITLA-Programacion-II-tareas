namespace CentroCapacitacionOficios.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
