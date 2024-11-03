using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Commands.Contacts;

namespace PhoneBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // Get: api/Contact/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        // Get: api/Contact/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // Post: api/Contact/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateContactCommand command)
        {
            return Ok();
        }

        // Put: api/Contact/Update
        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateContactCommand command)
        {
            return BadRequest();
        }

        // Delete: api/Contact/Delete
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteContactCommand command)
        {
            return Ok(0);
        }
    }
}
