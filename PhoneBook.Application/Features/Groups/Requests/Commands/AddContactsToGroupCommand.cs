using MediatR;
using PhoneBook.Application.DTOs.Contact;
using PhoneBook.Application.DTOs.ContactGroup;
using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Groups.Requests.Commands
{
    public class AddContactsToGroupCommand : IRequest
    {
        public int GroupId { get; set; }
        public string UserId { get; set; }
        public ContactGroupDto ContactGroupDto { get; set; }
    }
}
