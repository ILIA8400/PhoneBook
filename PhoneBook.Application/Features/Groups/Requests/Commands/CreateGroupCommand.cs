using MediatR;
using PhoneBook.Application.DTOs.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Groups.Requests.Commands
{
    public class CreateGroupCommand : IRequest<int>
    {
        public CreateGroupDto CreateGroupDto { get; set; }
        public string UserId { get; set; }
    }
}
