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
    public class UpdateContactHandler : IRequestHandler<UpdateContactCommand,string>
    {
        private readonly IContactRepository _repository;

        public UpdateContactHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contacts = await _repository.GetContactsForUserAsync(request.UserId);
            var contact = contacts.FirstOrDefault(contact => contact.Id == request.Id);
            contact.Name = request.Name;
            contact.Email = request.Email;
            contact.PhoneNumber = request.PhoneNumber;
            contact.Address = request.Address;
            contact.UpdatedDate = DateTime.UtcNow;
            contact.Groups = request.Groups;

            await _repository.Update(contact);
            return "Contact was updated.";
        }
    }
}
