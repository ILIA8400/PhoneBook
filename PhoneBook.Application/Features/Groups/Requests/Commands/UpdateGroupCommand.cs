using MediatR;
using PhoneBook.Application.DTOs.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Groups.Requests.Commands
{
    public class UpdateGroupCommand : IRequest<string>
    {
        public UpdateGroupDto UpdateGroupDto { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }
    }
}
