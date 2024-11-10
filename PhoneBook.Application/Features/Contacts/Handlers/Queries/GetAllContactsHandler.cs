using MediatR;
using PhoneBook.Application.Contracts.Contacts;
using PhoneBook.Application.Features.Contacts.Requests.Queries;
using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Contacts.Handlers.Queries
{
    public class GetAllContactsHandler : IRequestHandler<GetAllContactsRequest, List<Contact>>
    {
        private readonly IContactRepository repository;

        public GetAllContactsHandler(IContactRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Contact>> Handle(GetAllContactsRequest request, CancellationToken cancellationToken)
        {
            var contacts = await repository.GetAll(request.UserId);
            return contacts;
        }
    }
}
