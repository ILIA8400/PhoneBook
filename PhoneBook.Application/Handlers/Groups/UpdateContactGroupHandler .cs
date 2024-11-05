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
    public class UpdateContactGroupHandler : IRequestHandler<UpdateGroupCommand, ContactGroup>
    {
        private readonly IGroupRepository _repository;

        public UpdateContactGroupHandler(IGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContactGroup> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var contactGroups = await _repository.GetAllContactGroupUser(request.UserId);
            var contactGroup = contactGroups.FirstOrDefault(group => group.Id == request.Id);

            if (contactGroup == null)
                return null;

            contactGroup.GroupName = request.GroupName;
            return contactGroup;
        }
    }
}
