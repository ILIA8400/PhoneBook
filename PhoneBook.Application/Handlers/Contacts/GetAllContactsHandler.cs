using MediatR;
using PhoneBook.Application.Contracts.Contacts;
using PhoneBook.Application.DTOs.Contacts;
using PhoneBook.Application.Queries.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Handlers.Contacts
{
    public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, List<ContactDto>>
    {
        private readonly IContactRepository _repository;

        public GetAllContactsHandler(IContactRepository repository)
        {
            this._repository = repository;
        }
        public async Task<List<ContactDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _repository.GetContactsForUserAsync(request.UserId);
            var dtos = new List<ContactDto>();
            foreach (var contact in contacts)
            {
                new ContactDto()
                {
                    Name = contact.Name,
                    Address = contact.Address,
                    Email = contact.Email,
                    Groups = contact.Groups,
                    PhoneNumber = contact.PhoneNumber
                };
            }
            return dtos;
        }
    }
}
