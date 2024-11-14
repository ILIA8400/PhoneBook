using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.DTOs.Group.Validators
{
    public class IGroupValidator : AbstractValidator<IGroupDto>
    {
        public IGroupValidator()
        {
            RuleFor(x => x.GroupName).NotEmpty().WithMessage("این فیلد نباید خالی باشه")
                .Length(3, 55).WithMessage("طول این فیلد باید بین 3 تا 55 کاراکتر باشه");            
        }
    }
}
