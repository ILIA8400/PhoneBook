using MediatR;
using PhoneBook.Application.Contracts.Contacts;
using PhoneBook.Application.Exceptions;
using PhoneBook.Application.Features.Contacts.Requests.Queries;
using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Contacts.Handlers.Queries
{
    public class GetContactHandler : IRequestHandler<GetContactRequest, Contact>
    {
        private readonly IContactRepository repository;

        public GetContactHandler(IContactRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Contact> Handle(GetContactRequest request, CancellationToken cancellationToken)
        {
            var contact = await repository.Get(request.Id, request.Userid);
            if(contact == null) throw new NotFoundException("Contact not found");
            return contact;
        }
    }
}
