using FluentValidation;
using PhoneBook.Application.DTOs.Contact.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.DTOs.Group.Validators
{
    public class CreateGroupValidator : AbstractValidator<CreateGroupDto>
    {
        public CreateGroupValidator()
        {
            Include(new IGroupValidator());
        }
    }
}
