﻿using MediatR;
using PhoneBook.Application.Commands.Groups;
using PhoneBook.Application.Contracts.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Handlers.Groups
{   
    public class DeleteGroupHandler : IRequestHandler<DeleteGroupCommand, bool>
    {
        private readonly IGroupRepository _repository;

        public DeleteGroupHandler(IGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var contactGroups = await _repository.GetAllContactGroupUser(request.UserId);
            var contactGroup = contactGroups.FirstOrDefault(group => group.Id == request.Id);

            if (contactGroup == null)
                return false;

            await _repository.Delete(contactGroup);
            return true;
        }
    }
}
