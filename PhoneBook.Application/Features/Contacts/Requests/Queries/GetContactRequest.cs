using MediatR;
using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Contacts.Requests.Queries
{
    public class GetContactRequest : IRequest<Contact>
    {
        public required int Id { get; set; }
        public required string Userid { get; set; }
    }
}
