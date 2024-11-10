using MediatR;
using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Contacts.Requests.Queries
{
    public class GetAllContactsRequest : IRequest<List<Contact>>
    {
        public required string UserId { get; set; }
    }
}
