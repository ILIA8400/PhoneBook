using MediatR;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Groups.Requests.Queries
{
    public class GroupAllRequest : IRequest<List<Group>>
    {
        public string UserId { get; set; }
    }
}
