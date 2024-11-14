using MediatR;
using PhoneBook.Application.Contracts.Groups;
using PhoneBook.Application.Features.Groups.Requests.Queries;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Groups.Handlers.Queries
{
    public class GetAllGroupsHandler : IRequestHandler<GroupAllRequest, List<Group>>
    {
        private readonly IGroupRepository repository;

        public GetAllGroupsHandler(IGroupRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Group>> Handle(GroupAllRequest request, CancellationToken cancellationToken)
        {       
            return await repository.GetAll(request.UserId);
        }
    }
}
