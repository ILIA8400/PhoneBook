using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Commands.Contacts
{
    public class DeleteContactCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
    }
}
