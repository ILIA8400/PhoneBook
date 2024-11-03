using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactGroupController : ControllerBase
    {
        // GET: api/<ContactGroupController>/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        // GET api/<ContactGroupController>/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // POST api/<ContactGroupController>/Create
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }

        // PUT api/<ContactGroupController>/Update
        [HttpPut("Update")]
        public async Task<IActionResult> Put()
        {
            return Ok();
        }

        // DELETE api/<ContactGroupController>/Delete/5
        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(0);
        }
    }
}
