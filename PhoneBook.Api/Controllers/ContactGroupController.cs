using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Commands.Groups;
using PhoneBook.Application.Queries.Groups;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class ContactGroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactGroupController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<ContactGroupController>/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var query = new GetAllGroupsRequest { UserId = userId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // POST api/<ContactGroupController>/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateGroupCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("model not valid");
            }
            command.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT api/<ContactGroupController>/Update
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateGroupCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("model not valid");
            }
            command.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE api/<ContactGroupController>/Delete/{id}
        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var command = new DeleteGroupCommand { Id = id, UserId = userId };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
