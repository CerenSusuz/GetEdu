using BaseCore.Entities.Concrete.Dtos.BaseDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).Length(2, 50);
            RuleFor(x => x.LastName).Length(2, 50);
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
