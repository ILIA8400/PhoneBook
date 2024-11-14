﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.DTOs.ContactGroup;
using PhoneBook.Application.Features.Groups.Requests.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactGroupController : ControllerBase
    {
        private readonly IMediator mediator;

        public ContactGroupController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // Put : api/Group/AddContactsToGroup?{Id}
        [HttpPut]
        public async Task<IActionResult> AddContactsToGroup([FromBody] ContactGroupDto dto, [FromQuery] int groupId)
        {
            var request = new AddContactsToGroupCommand() { UserId = User.Identity.Name, GroupId = groupId, ContactGroupDto = dto };
            await mediator.Send(request);
            return NoContent();
        }

        // PUT api/<ContactGroupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContactGroupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
