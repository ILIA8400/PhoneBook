using MediatR;
using PhoneBook.Application.Contracts.Groups;
using PhoneBook.Application.Queries.Groups;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Handlers.Groups
{
    public class GetAllContactGroupsHandler : IRequestHandler<GetAllGroupsRequest, List<ContactGroup>>
    {
        private readonly IGroupRepository _repository;

        public GetAllContactGroupsHandler(IGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ContactGroup>> Handle(GetAllGroupsRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllContactGroupUser(request.UserId);              
        }
    }
}
