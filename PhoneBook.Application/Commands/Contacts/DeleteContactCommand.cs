using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Commands.Contacts
{
    public class DeleteContactCommand : IRequest
    {
        public int Id { get; set; }
    }
}
