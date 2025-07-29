using Microsoft.AspNetCore.Mvc;
using CentroCapacitacionOficios.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using Microsoft.VisualBasic;
using CentroCapacitacionOficios.DTOs;
using CentroCapacitacionOficios.Infrastructure.Data;

namespace CentroCapacitacionOficios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly CentroCapacitacionOficiosDataContext _context;
        public CoursesController(CentroCapacitacionOficiosDataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetCourses(int id)
        {
            var course = _context.Courses.Where(p => p.Id == id).FirstOrDefault();
            return Ok(course);
        }

        [HttpPost]
        public IActionResult CreateCourses([FromBody] CreateCourseDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Course cannot be null.");
            }
            var course = new Course
            {
                Name = dto.Name,
                Description = dto.Description,
                DurationHours = dto.DurationHours,
                InstructorId = dto.InstructorId
            };

            _context.Add(course);
            _context.SaveChanges();
            return Ok(new { id = course.Id });
        }

        [HttpPut]
        public IActionResult UpdateCourses([FromBody] UpdateCourseDto dto)
        {
            if (dto == null || dto.Id <= 0)
            {
                return BadRequest("invalid course data");
            }
            var existingCourse = _context.Courses.FirstOrDefault(d => d.Id == dto.Id);
            if (existingCourse == null)
            {
                return NotFound("Course no found");
            }
            existingCourse.Name = dto.Name;
            existingCourse.Description = dto.Description;
            existingCourse.DurationHours = dto.DurationHours;
            existingCourse.InstructorId = dto.InstructorId;

            _context.Courses.Update(existingCourse);
            _context.SaveChanges();

            return NoContent();

        }

        [HttpDelete]
        public IActionResult DeleteCourses(int id)
        {
            var course = _context.Courses.FirstOrDefault(d => d.Id == id);
            if (course == null)
            {
                return NotFound("Course no found");
            }
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
