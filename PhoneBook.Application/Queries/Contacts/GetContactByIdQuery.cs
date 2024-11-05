using MediatR;
using PhoneBook.Application.DTOs.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Queries.Contacts
{
    public class GetContactByIdQuery : IRequest<ContactDto>
    {
        public required int Id { get; set; }
        public string UserId { get; set; }
    }
}
