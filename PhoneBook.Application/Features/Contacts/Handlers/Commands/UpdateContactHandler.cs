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
    public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, string>
    {
        private readonly IContactRepository repository;
        private readonly IMapper mapper;

        public UpdateContactHandler(IContactRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<string> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateContactValidator();
            var validationResult = await validator.ValidateAsync(request.updateContactDto,cancellationToken);

            if (!validationResult.IsValid) throw new ValidationException(validationResult);

            var contact = await repository.Get(request.Id,request.UserId);

            if (contact == null)
                throw new NotFoundException("Not Found !!!");

            mapper.Map(request.updateContactDto,contact);
            contact.UpdatedDate = DateTime.UtcNow;

            await repository.Update(contact);

            return "The update was successful";
        }
    }
}
