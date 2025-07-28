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

        //GET:
        //Se utiliza para recuperar información de un recurso específico o una colección de recursos.

        [HttpGet("{id}")]
        public IActionResult GetInstructors(int id)
        {
            var instructor = _context.Instructors.Where(p => p.Id == id).FirstOrDefault();
            return Ok(instructor);
        }

        //POST:
        //Se utiliza para crear un nuevo recurso.

        [HttpPost]
        public IActionResult CreateInstructor([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null.");
            }

            _context.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        //PUT:
        //Se utiliza para actualizar un recurso existente por completo.

        [HttpPut]
        public IActionResult UpdateInstructor([FromBody] Instructor instructor)
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

        //DELETE:
        //Se utiliza para eliminar un recurso existente.

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(d => d.Id == id);
            if (user == null)
            {
                return NotFound("User no found");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
