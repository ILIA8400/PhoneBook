using MediatR;
using PhoneBook.Application.Contracts.Contacts;
using PhoneBook.Application.Contracts.Groups;
using PhoneBook.Application.DTOs.Contact.Validators;
using PhoneBook.Application.DTOs.ContactGroup.Validators;
using PhoneBook.Application.Exceptions;
using PhoneBook.Application.Features.Groups.Requests.Commands;
using PhoneBook.Domain.Contacts;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Groups.Handlers.Commands
{
    public class AddContactsToGroupHandler : IRequestHandler<AddContactsToGroupCommand>
    {
        private readonly IGroupRepository groupRepository;
        private readonly IContactRepository contactRepository;

        public AddContactsToGroupHandler(IGroupRepository groupRepository,IContactRepository contactRepository)
        {
            this.groupRepository = groupRepository;
            this.contactRepository = contactRepository;
        }

        public async Task Handle(AddContactsToGroupCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddContactGroupValidator();
            var validationResult = await validator.ValidateAsync(request.ContactGroupDto, cancellationToken);

            if (!validationResult.IsValid) throw new ValidationException(validationResult);

            var contacts = await contactRepository.GetAll(request.UserId);
            var selectContact = new List<Contact>();
            foreach (var item in contacts)
            {
                if (!request.ContactGroupDto.ContatcsIds.Contains(item.Id)) continue;

                selectContact.Add(item);               
            }

        }
    }
}
