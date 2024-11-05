using MediatR;
using PhoneBook.Application.Commands.Contacts;
using PhoneBook.Application.Contracts.Contacts;
using PhoneBook.Application.DTOs.Contacts;
using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Handlers.Contacts
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, CreateContactResponse>
    {
        private readonly IContactRepository _repository;

        public CreateContactHandler(IContactRepository repository)
        {
            _repository = repository;
        }
        public async Task<CreateContactResponse> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact()
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                Groups = request.Groups,
                UserId = request.UserId
            };

            var response = new CreateContactResponse();

            try
            {
                await _repository.Add(contact);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
