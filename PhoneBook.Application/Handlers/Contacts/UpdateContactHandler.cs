using MediatR;
using PhoneBook.Application.Commands.Contacts;
using PhoneBook.Application.Contracts.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Handlers.Contacts
{
    public class UpdateContactHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IContactRepository _repository;

        public UpdateContactHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _repository.Get(request.Id);
            contact.Name = request.Name;
            contact.Email = request.Email;
            contact.PhoneNumber = request.PhoneNumber;
            contact.Address = request.Address;
            contact.UpdatedDate = DateTime.UtcNow;
            contact.Groups = request.Groups;

            await _repository.Update(contact);
        }
    }
}
