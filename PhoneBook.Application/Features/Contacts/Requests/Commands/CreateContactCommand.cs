using MediatR;
using PhoneBook.Application.DTOs.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Contacts.Requests.Commands
{
    public class CreateContactCommand : IRequest<int>
    {
        public CreateContactDto CreateContactDto { get; set; }
        public string UserId { get; set; }
    }
}
