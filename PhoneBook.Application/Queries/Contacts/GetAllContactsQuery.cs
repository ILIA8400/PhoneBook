using MediatR;
using PhoneBook.Application.DTOs.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Queries.Contacts
{
    public class GetAllContactsQuery : IRequest<List<ContactDto>>
    {
        public string UserId { get; set; }
    }
}
