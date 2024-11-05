using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Commands.Contacts;
using PhoneBook.Application.DTOs;
using PhoneBook.Application.DTOs.Contacts;
using PhoneBook.Application.Queries.Contacts;
using System.Security.Claims;

namespace PhoneBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]

    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // Get: api/Contact/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _mediator.Send(new GetAllContactsQuery().UserId = userId));
        }

        // Get: api/Contact/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var request = new GetContactByIdQuery()
            {
                Id = id,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            return Ok(await _mediator.Send(request));
        }

        // Post: api/Contact/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create(ContactDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("model not valid");
            }
            var command = new CreateContactCommand()
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Groups  = dto.Groups,
                Address = dto.Address,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // Put: api/Contact/Update
        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateContactDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("model not valid");
            }
            var command = new UpdateContactCommand
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Groups = dto.Groups,
                Address = dto.Address,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // Delete: api/Contact/Delete
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteContactDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("model not valid");
            }
            var command = new DeleteContactCommand()
            {
                Id = dto.Id,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}
