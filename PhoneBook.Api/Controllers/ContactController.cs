using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Features.Contacts.Requests.Queries;
using Microsoft.AspNetCore.Identity;
using MediatR;
using PhoneBook.Application.DTOs.Contact;
using PhoneBook.Application.Features.Contacts.Requests.Commands;
using PhoneBook.Application.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IMediator mediator;

        public ContactController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var request = new GetAllContactsRequest()
            {
                UserId = User.Identity.Name
            };

            return Ok(await mediator.Send(request));
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContactDto dto)
        {
            var request = new CreateContactCommand { CreateContactDto = dto, UserId = User.Identity.Name };
            try
            {
                var result = await mediator.Send(request);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            return Ok();
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
