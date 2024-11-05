using MediatR;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Queries.Groups
{
    public class GetAllGroupsRequest : IRequest<List<ContactGroup>>
    {
        public string UserId { get; set; }
    }
}
