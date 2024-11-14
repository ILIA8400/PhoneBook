using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts.Groups;
using PhoneBook.Application.DTOs.Group.Validators;
using PhoneBook.Application.Exceptions;
using PhoneBook.Application.Features.Groups.Requests.Commands;
using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Groups.Handlers.Commands
{
    public class UpdateGroupHandler : IRequestHandler<UpdateGroupCommand, string>
    {
        private readonly IGroupRepository repository;
        private readonly IMapper mapper;

        public UpdateGroupHandler(IGroupRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<string> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGroupValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateGroupDto, cancellationToken);

            if (!validationResult.IsValid) throw new ValidationException(validationResult);

            var group = await repository.Get(request.Id,request.UserId);
            
            if (group == null)
                throw new NotFoundException("Not Found !!!");

            mapper.Map(request.UpdateGroupDto, group);

            group.UpdatedDate = DateTime.UtcNow;
            await repository.Update(group);

            return "The update was successful";
        }
    }
}
