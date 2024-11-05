using MediatR;
using PhoneBook.Application.Commands.Groups;
using PhoneBook.Application.Contracts.Groups;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Handlers.Groups
{
    public class CreateContactGroupHandler : IRequestHandler<CreateGroupCommand, ContactGroup>
    {
        private readonly IGroupRepository _repository;

        public CreateContactGroupHandler(IGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContactGroup> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var contactGroup = new ContactGroup
            {
                GroupName = request.GroupName,
                UserId = request.UserId
            };

            await _repository.Add(contactGroup);
            return contactGroup;
        }
    }
}
