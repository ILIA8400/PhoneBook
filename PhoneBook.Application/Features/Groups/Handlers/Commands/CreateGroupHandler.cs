using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts.Contacts;
using PhoneBook.Application.Contracts.Groups;
using PhoneBook.Application.DTOs.Contact.Validators;
using PhoneBook.Application.DTOs.Group.Validators;
using PhoneBook.Application.Exceptions;
using PhoneBook.Application.Features.Contacts.Requests.Commands;
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
    public class CreateGroupHandler : IRequestHandler<CreateGroupCommand, int>
    {
        private readonly IGroupRepository repository;
        private readonly IMapper mapper;

        public CreateGroupHandler(IGroupRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateGroupValidator();
            var validationResult = await validator.ValidateAsync(request.CreateGroupDto, cancellationToken);

            if (!validationResult.IsValid) throw new ValidationException(validationResult);

            var group = mapper.Map<Group>(request.CreateGroupDto);
            group.UserId = request.UserId;
            group = await repository.Add(group);

            return group.Id;
        }
    }
}
