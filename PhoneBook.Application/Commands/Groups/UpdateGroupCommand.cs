using MediatR;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Commands.Groups
{
    public class UpdateGroupCommand : IRequest<ContactGroup>
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string UserId { get; set; }
    }
}
