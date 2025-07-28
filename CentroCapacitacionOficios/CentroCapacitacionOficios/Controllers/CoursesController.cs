using Microsoft.AspNetCore.Mvc;
using CentroCapacitacionOficios.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using Microsoft.VisualBasic;
using CentroCapacitacionOficios.Data;

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
        public IActionResult CreateCourses([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest("Course cannot be null.");
            }

            _context.Add(course);
            _context.SaveChanges();
            return Ok(course);
        }

        [HttpPut]
        public IActionResult UpdateCourses([FromBody] Course course)
        {
            if (course == null || course.Id <= 0)
            {
                return BadRequest("invalid course data");
            }
            var existingCourse = _context.Courses.FirstOrDefault(d => d.Id == course.Id);
            if (existingCourse == null)
            {
                return NotFound("Course no found");
            }
            existingCourse.Name = course.Name;
            existingCourse.Description = course.Description;
            existingCourse.DurationHours = course.DurationHours;
            existingCourse.InstructorId = course.InstructorId;

            _context.Courses.Update(existingCourse);
            _context.SaveChanges();

            return Ok(course);

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
