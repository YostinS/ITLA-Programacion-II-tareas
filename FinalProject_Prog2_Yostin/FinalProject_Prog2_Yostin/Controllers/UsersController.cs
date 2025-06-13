using Microsoft.AspNetCore.Mvc;

namespace FinalProject_Prog2_Yostin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {

            return Ok();
        }
    }
}
