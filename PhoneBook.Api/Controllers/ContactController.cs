using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Features.Contacts.Requests.Queries;
using Microsoft.AspNetCore.Identity;
using MediatR;
using PhoneBook.Application.DTOs.Contact;
using PhoneBook.Application.Features.Contacts.Requests.Commands;
using PhoneBook.Application.Exceptions;
using Azure;
using PhoneBook.Domain.Contacts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        public async Task<IActionResult> Get(int id)
        {
            var request = new GetContactRequest() { Id = id , Userid = User.Identity.Name};
            try
            {
                var contact = await mediator.Send(request);
                return Ok(contact);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }          
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContactDto dto)
        {
            var request = new CreateContactCommand { CreateContactDto = dto, UserId = User.Identity.Name };
            try
            {
                var result = await mediator.Send(request);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }            
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] UpdateContactDto updateContactDto)
        {
            var request = new UpdateContactCommand { updateContactDto = updateContactDto, UserId = User.Identity.Name, Id = id };
            await mediator.Send(request);
            return NoContent();
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteContactCommand { Id = id, UserId = User.Identity.Name };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
