using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.DTOs.Group;
using PhoneBook.Application.Features.Groups.Requests.Commands;
using PhoneBook.Application.Features.Groups.Requests.Queries;
using PhoneBook.Domain.Contacts;
using PhoneBook.Domain.Groups;

namespace PhoneBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupController : ControllerBase
    {
        private readonly IMediator mediator;

        public GroupController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // Get : api/Group/All
        [HttpGet("All")]
        public async Task<IActionResult> GetGroups()
        {
            var request = new GroupAllRequest() { UserId = User.Identity.Name };

            return Ok(await mediator.Send(request));
        }

        // Post : api/Group
        [HttpPost]
        public async Task<IActionResult> Post(CreateGroupDto dto)
        {
            var request = new CreateGroupCommand() { UserId = User.Identity.Name, CreateGroupDto = dto };
            return Ok(await mediator.Send(request));
        }

        // Put : api/Group/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateGroupDto dto)
        {
            var request = new UpdateGroupCommand() { UpdateGroupDto = dto, UserId = User.Identity.Name, Id = id };
            await mediator.Send(request);
            return NoContent();
        }

        // Delete : api/Group/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteGroupCommand() { UserId = User.Identity.Name, Id = id };
            await mediator.Send(request);
            return NoContent();
        }       
    }
}
