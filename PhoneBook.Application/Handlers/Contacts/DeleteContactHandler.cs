using MediatR;
using PhoneBook.Application.Commands.Contacts;
using PhoneBook.Application.Contracts.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Handlers.Contacts
{
    public class DeleteContactHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly IContactRepository _repository;

        public DeleteContactHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.Get(request.Id);
            if (entity == null)
            {
                throw new Exception("Entity Not Found.");
            }

            await _repository.Delete(entity);
        }
    }
}
