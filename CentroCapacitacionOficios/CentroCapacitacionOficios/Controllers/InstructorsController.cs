using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using Microsoft.VisualBasic;
using CentroCapacitacionOficios.DTOs;
using CentroCapacitacionOficios.Domain.Entities;
using CentroCapacitacionOficios.Infrastructure.Data;

namespace CentroCapacitacionOficios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorsController : ControllerBase
    {
        private readonly CentroCapacitacionOficiosDataContext _context;
        public InstructorsController(CentroCapacitacionOficiosDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllInstructors()
        {
            var instructors = _context.Instructors.ToList();
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public IActionResult GetInstructors(int id)
        {
            var instructor = _context.Instructors.Where(p => p.Id == id).FirstOrDefault();
            return Ok(instructor);
        }

        [HttpPost]
        public IActionResult CreateInstructors([FromBody] CreateInstructorDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Instructor cannot be null.");
            }
            var instructor = new Instructor
            {
                Name = dto.Name,
                Specialty = dto.Specialty,
                Email = dto.Email
            };

            _context.Add(instructor);
            _context.SaveChanges();
            return Ok(new { id = instructor.Id });
        }

        [HttpPut]
        public IActionResult UpdateInstructors([FromBody] UpdateInstructorDto dto)
        {
            if (dto == null || dto.Id <= 0)
            {
                return BadRequest("invalid instructor data");
            }
            var existingInstructor = _context.Instructors.FirstOrDefault(d => d.Id == dto.Id);
            if (existingInstructor == null)
            {
                return NotFound("Instructor no found");
            }
            existingInstructor.Name = dto.Name;
            existingInstructor.Specialty = dto.Specialty;
            existingInstructor.Email = dto.Email;
            
            _context.Instructors.Update(existingInstructor);
            _context.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInstructors(int id)
        {
            var instructor = _context.Instructors.FirstOrDefault(d => d.Id == id);
            if (instructor == null)
            {
                return NotFound("Instructor no found");
            }
            _context.Instructors.Remove(instructor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
