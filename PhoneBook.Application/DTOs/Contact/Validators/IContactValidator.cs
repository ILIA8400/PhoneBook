using FluentValidation;
using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.DTOs.Contact.Validators
{
    public class IContactValidator : AbstractValidator<IContactDto>
    {
        public IContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("این فیلد نباید خالی باشه")
                .Length(3,55).WithMessage("طول این فیلد باید بین 3 تا 55 کاراکتر باشه");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("این فیلد نباید خالی باشه")
                .Length(11,11).WithMessage("شماره تلفن معتبر نیست");

            RuleFor(x => x.Email).EmailAddress().WithMessage("ایمیل معتبر نیست")
                .MaximumLength(255).WithMessage("طول ایمیل نمیتواند بیشتر از 255 کاراکتر باشد");

            RuleFor(x => x.Address).MaximumLength(255).WithMessage("طول ادرس نمیتواند بیشتر از 255 کاراکتر باشد");
        }
    }
}
