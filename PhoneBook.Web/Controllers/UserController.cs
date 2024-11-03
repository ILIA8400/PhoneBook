using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        // Post: api/User/Register
        [HttpPost]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }

        // Post: api/User/Login
        [HttpPost]
        public async Task<IActionResult> Login()
        {
            return BadRequest();
        }

        // Post api/User/Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            return NoContent();
        }

    }
}
