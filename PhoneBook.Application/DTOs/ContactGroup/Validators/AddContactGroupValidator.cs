using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.DTOs.ContactGroup.Validators
{
    public class AddContactGroupValidator : AbstractValidator<ContactGroupDto>
    {
        public AddContactGroupValidator()
        {
            RuleFor(c => c.ContatcsIds).NotNull().WithMessage("این فیلد نباید خالی باشه");
        }
    }
}
