using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts.Contacts;
using PhoneBook.Application.Exceptions;
using PhoneBook.Application.Features.Contacts.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Contacts.Handlers.Commands
{
    public class DeleteContactHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly IContactRepository repository;
        private readonly IMapper mapper;

        public DeleteContactHandler(IContactRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await repository.Get(request.Id, request.UserId);

            if (contact == null)
                throw new NotFoundException("Not Found !!!");

            await repository.Delete(contact);           
        }
    }
}
