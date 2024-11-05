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
    public class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, ContactDto>
    {
        private readonly IContactRepository _repository;

        public GetContactByIdHandler(IContactRepository repository)
        {
            this._repository = repository;
        }

        public async Task<ContactDto> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _repository.GetContactsForUserAsync(request.UserId);
            var contact = contacts.FirstOrDefault(x => x.Id == request.Id);
            if (contact == null)
            {
                throw new Exception("contact is not exist");
            }

            return new ContactDto
            {
                Name = contact.Name,
                Address = contact.Address,
                Email = contact.Email,
                Groups = contact.Groups,
                PhoneNumber = contact.PhoneNumber          
            };
        }
    }
}
