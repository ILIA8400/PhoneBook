using MediatR;
using PhoneBook.Application.Contracts.Contacts;
using PhoneBook.Application.Contracts.Groups;
using PhoneBook.Application.DTOs.ContactGroup.Validators;
using PhoneBook.Application.Exceptions;
using PhoneBook.Application.Features.Groups.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Groups.Handlers.Commands
{
    public class DeleteContactGroupHandler : IRequestHandler<DeleteContactGroupCommand>
    {
        private readonly IGroupRepository groupRepository;
        private readonly IContactRepository contactRepository;

        public DeleteContactGroupHandler(IGroupRepository groupRepository, IContactRepository contactRepository)
        {
            this.groupRepository = groupRepository;
            this.contactRepository = contactRepository;
        }

        public async Task Handle(DeleteContactGroupCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddContactGroupValidator();
            var validationResult = await validator.ValidateAsync(request.ContactGroupDto, cancellationToken);

            if (!validationResult.IsValid) throw new ValidationException(validationResult);


            var contacts = await contactRepository.GetAll(request.UserId);
            var selectContact = contacts
                .Where(item => request.ContactGroupDto.ContatcsIds.Contains(item.Id))
                .ToList();

            var group = await groupRepository.Get(request.GroupId, request.UserId);

            foreach (var contact in selectContact)
            {
                if (contact.Groups.Contains(group))
                {
                    contact.Groups.Remove(group);
                }
            }

            await contactRepository.SaveChanges();
        }
    }
}
