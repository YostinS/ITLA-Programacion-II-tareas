using Microsoft.AspNetCore.Mvc;
using CentroCapacitacionOficios.Entities;
using CentroCapacitacionOficios.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using Microsoft.VisualBasic;

namespace CentroCapacitacionOficios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly CentroCapacitacionOficiosDataContext _context;
        public VideosController(CentroCapacitacionOficiosDataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetVideos(int id)
        {
            var video = _context.Videos.Where(p => p.Id == id).FirstOrDefault();
            return Ok(video);
        }

        [HttpPost]
        public IActionResult CreateVideos([FromBody] Video video)
        {
            if (video == null)
            {
                return BadRequest("Video cannot be null. Need a valid link");
            }

            _context.Add(video);
            _context.SaveChanges();
            return Ok(video);
        }

        [HttpPut]
        public IActionResult UpdateVideos([FromBody] Video video)
        {
            if (video == null || video.Id <= 0)
            {
                return BadRequest("invalid video data");
            }
            var existingVideo = _context.Videos.FirstOrDefault(d => d.Id == video.Id);
            if (existingVideo == null)
            {
                return NotFound("Instructor no found");
            }
            existingVideo.Title = video.Title;
            existingVideo.VideoUrl = video.VideoUrl;
            existingVideo.CourseId = video.CourseId;

            _context.Videos.Update(existingVideo);
            _context.SaveChanges();

            return Ok(video);

        }

        [HttpDelete]
        public IActionResult DeleteVideos(int id)
        {
            var video = _context.Videos.FirstOrDefault(d => d.Id == id);
            if (video == null)
            {
                return NotFound("Video no found");
            }
            _context.Videos.Remove(video);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
