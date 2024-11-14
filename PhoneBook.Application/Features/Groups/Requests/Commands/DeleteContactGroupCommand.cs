using MediatR;
using PhoneBook.Application.DTOs.ContactGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Groups.Requests.Commands
{
    public class DeleteContactGroupCommand : IRequest
    {
        public ContactGroupDto ContactGroupDto { get; set; }
        public int GroupId { get; set; }
        public string UserId { get; set; }
    }
}
