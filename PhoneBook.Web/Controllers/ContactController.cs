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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        // Get: api/Contact/Get/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // Post: api/Contact/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactCommand command)
        {
            return Ok();
        }

        // Put: api/Contact/Update
        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactCommand command)
        {
            return BadRequest();
        }

        // Delete: api/Contact/Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteContactCommand command)
        {
            return Ok(0);
        }
    }
}
