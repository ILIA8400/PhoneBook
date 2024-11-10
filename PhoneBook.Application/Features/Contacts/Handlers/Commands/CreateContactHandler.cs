using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts.Contacts;
using PhoneBook.Application.DTOs.Contact.Validators;
using PhoneBook.Application.Exceptions;
using PhoneBook.Application.Features.Contacts.Requests.Commands;
using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Contacts.Handlers.Commands
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly IContactRepository repository;
        private readonly IMapper mapper;

        public CreateContactHandler(IContactRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateContactValidator();
            var validationResult = await validator.ValidateAsync(request.CreateContactDto, cancellationToken);

            if (!validationResult.IsValid) throw new ValidationException(validationResult);

            var contact = mapper.Map<Contact>(request.CreateContactDto);
            contact.UserId = request.UserId;
            contact = await repository.Add(contact);

            return contact.Id;
        }
    }
}
