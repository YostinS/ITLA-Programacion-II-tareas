using Microsoft.AspNetCore.Mvc;
using CentroCapacitacionOficios_FinalProject_Prog2.Entities;
/*
Rest Verbs
GET:
Se utiliza para recuperar información de un recurso específico o una colección de recursos. Por ejemplo, obtener los detalles de un usuario o una lista de productos.

POST:
Se utiliza para crear un nuevo recurso. Por ejemplo, crear una nueva publicación en un blog o un nuevo pedido en una tienda online.

PUT:
Se utiliza para actualizar un recurso existente por completo. Por ejemplo, actualizar todos los datos de un perfil de usuario.

DELETE:
Se utiliza para eliminar un recurso existente. Por ejemplo, eliminar un producto de la base de datos o un archivo de un servidor. 
 */
namespace CentroCapacitacionOficios_FinalProject_Prog2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private List<User> _users;
        public UsersController()
        {
            _users = new List<User>();
            _users.Add(new User { Id = 1, Name = "Yostin Sanchez", Email = "emailyostinprueba@gmail.com", RegistrationDate = new DateTime(2024, 05, 04) });
            _users.Add(new User { Id = 2, Name = "David Martinez", Email = "cyberpunk2077@gmail.com", RegistrationDate = new DateTime(2025, 01, 15) });
            _users.Add(new User { Id = 3, Name = "Kratos", Email = "turealdios@gmail.com", RegistrationDate = new DateTime(2018, 04, 20) });
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_users);
        }
        [HttpGet("{id}")]
        public IActionResult GetUsers(int id)
        {
            User user = new User();
            //foreach (var item in _users)
            //{
            //    if (item.Id == id)
            //    {
            //        user = item;
            //        break;
            //        //return Ok(user);
            //    }

            //}
            user = _users.Where( s => s.Id == id).FirstOrDefault();
            if (user == null)
            {
                return NotFound($"User with ID {id} no found, please check ID again.");
            }
            return Ok(user);
        }

    }
}
