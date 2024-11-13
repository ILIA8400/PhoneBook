using MediatR;
using PhoneBook.Application.DTOs.Contact;
using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Contacts.Requests.Commands
{
    public class UpdateContactCommand : IRequest<string>
    {
        public UpdateContactDto updateContactDto { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }
    }
}
