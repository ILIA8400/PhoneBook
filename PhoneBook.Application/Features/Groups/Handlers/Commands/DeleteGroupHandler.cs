using MediatR;
using PhoneBook.Application.Contracts.Groups;
using PhoneBook.Application.Exceptions;
using PhoneBook.Application.Features.Groups.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Groups.Handlers.Commands
{
    public class DeleteGroupHandler : IRequestHandler<DeleteGroupCommand>
    {
        private readonly IGroupRepository repository;

        public DeleteGroupHandler(IGroupRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await repository.Get(request.Id, request.UserId);

            if (group == null) throw new NotFoundException("Not Found !!!");

            await repository.Delete(group);
        }
    }
}
