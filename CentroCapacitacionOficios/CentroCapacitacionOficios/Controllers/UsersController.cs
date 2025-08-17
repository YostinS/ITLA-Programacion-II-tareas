using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using Microsoft.VisualBasic;
using CentroCapacitacionOficios.DTOs;
using System.Data;
using CentroCapacitacionOficios.Infrastructure.Data;
using CentroCapacitacionOficios.Domain.Entities;

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
        public IActionResult CreateUser([FromBody] CreateUserDto dto)
        {
            if (dto == null)
            {
                return BadRequest("User cannot be null.");
            }
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                RegistrationDate = DateTime.UtcNow, //dto.RegistrationDate
                Password = dto.Password // Assuming Password is part of CreateUserDto
            };
            _context.Add(user);
            _context.SaveChanges();
            return Ok(new {id = user.Id});
        }

        //PUT:
        //Se utiliza para actualizar un recurso existente por completo.

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UpdateUserDto dto)
        {
            if (dto == null || dto.Id <= 0)
            {
                return BadRequest("invalid user data");
            }
            var existingUser = _context.Users.FirstOrDefault(d => d.Id == dto.Id);
            if (existingUser == null)
            {
                return NotFound("User no found");
            }
            existingUser.Name = dto.Name;
            existingUser.Email = dto.Email;
            existingUser.RegistrationDate = dto.RegistrationDate;

            _context.Users.Update(existingUser);
            _context.SaveChanges();

            return NoContent();

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
