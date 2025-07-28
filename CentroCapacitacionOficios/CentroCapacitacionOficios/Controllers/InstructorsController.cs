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
    public class InstructorsController : ControllerBase
    {
        private readonly CentroCapacitacionOficiosDataContext _context;
        public InstructorsController(CentroCapacitacionOficiosDataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetInstructors(int id)
        {
            var instructor = _context.Instructors.Where(p => p.Id == id).FirstOrDefault();
            return Ok(instructor);
        }

        [HttpPost]
        public IActionResult CreateInstructors([FromBody] Instructor instructor)
        {
            if (instructor == null)
            {
                return BadRequest("Instructor cannot be null.");
            }

            _context.Add(instructor);
            _context.SaveChanges();
            return Ok(instructor);
        }

        [HttpPut]
        public IActionResult UpdateInstructors([FromBody] Instructor instructor)
        {
            if (instructor == null || instructor.Id <= 0)
            {
                return BadRequest("invalid instructor data");
            }
            var existingInstructor = _context.Instructors.FirstOrDefault(d => d.Id == instructor.Id);
            if (existingInstructor == null)
            {
                return NotFound("Instructor no found");
            }
            existingInstructor.Name = instructor.Name;
            existingInstructor.Specialty = instructor.Specialty;
            existingInstructor.Email = instructor.Email;
            
            _context.Instructors.Update(existingInstructor);
            _context.SaveChanges();

            return Ok(instructor);

        }

        [HttpDelete]
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
