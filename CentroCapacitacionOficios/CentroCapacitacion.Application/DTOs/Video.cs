namespace CentroCapacitacionOficios.Application.DTOs
{
    public class VideoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public int CourseId { get; set; }
        public CourseDto Course { get; set; }
    }
}
