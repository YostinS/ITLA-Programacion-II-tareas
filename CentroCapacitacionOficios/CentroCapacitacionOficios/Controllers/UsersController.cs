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
    public class UsersController : ControllerBase
    {
        private readonly CentroCapacitacionOficiosDataContext _context;
        //private List<User> _users;
        public UsersController(CentroCapacitacionOficiosDataContext context)
        {
            _context = context;
            //_context.Add(new User { Id = 1, Name = "Yostin Sanchez", Email = "emailyostinprueba@gmail.com", RegistrationDate = new DateTime(2024, 05, 04) });
            //_context.Add(new User { Id = 2, Name = "David Martinez", Email = "cyberpunk2077@gmail.com", RegistrationDate = new DateTime(2025, 01, 15) });
            //_context.Add(new User { Id = 3, Name = "Kratos", Email = "turealdios@gmail.com", RegistrationDate = new DateTime(2018, 04, 20) });

        }

        //GET:
        //Se utiliza para recuperar información de un recurso específico o una colección de recursos.

        [HttpGet("{id}")]
        public IActionResult GetUsers(int id)
        {
            var user = _context.Users.Where(p => p.Id == id).FirstOrDefault();
            return Ok(user);
        }

        //POST:
        //Se utiliza para crear un nuevo recurso.

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
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
        public IActionResult UpdateUser([FromBody] User user)
        {
            if (user == null || user.Id <= 0)
            {
                return BadRequest("invalid user data");
            }
            var existingUser = _context.Users.FirstOrDefault(d =>  d.Id == user.Id);
            if (existingUser == null)
            {
                return NotFound("User no found");
            }
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.RegistrationDate = user.RegistrationDate;
            _context.Users.Update(existingUser);
            _context.SaveChanges();

            return Ok(user);

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
