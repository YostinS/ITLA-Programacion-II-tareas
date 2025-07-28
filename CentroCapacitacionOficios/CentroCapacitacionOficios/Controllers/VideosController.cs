using Microsoft.AspNetCore.Mvc;
using CentroCapacitacionOficios.Entities;
using CentroCapacitacionOficios.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using Microsoft.VisualBasic;
using CentroCapacitacionOficios.DTOs;

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
        public IActionResult CreateVideos([FromBody] CreateVideoDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Video cannot be null. Need a valid link");
            }
            var video = new Video
            {
                Title = dto.Title,
                VideoUrl = dto.VideoUrl,
                CourseId = dto.CourseId
            };

            _context.Add(video);
            _context.SaveChanges();
            return Ok(new { id = video.Id });
        }

        [HttpPut]
        public IActionResult UpdateVideos([FromBody] UpdateVideoDto dto)
        {
            if (dto == null || dto.Id <= 0)
            {
                return BadRequest("invalid video data");
            }
            var existingVideo = _context.Videos.FirstOrDefault(d => d.Id == dto.Id);
            if (existingVideo == null)
            {
                return NotFound("Instructor no found");
            }
            existingVideo.Title = dto.Title;
            existingVideo.VideoUrl = dto.VideoUrl;
            existingVideo.CourseId = dto.CourseId;

            _context.Videos.Update(existingVideo);
            _context.SaveChanges();

            return NoContent();

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
