using Business.Dtos.Request.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.AuthValidator
{
    public class CreateLoginValidator:AbstractValidator<CreateLoginRequest>
    {
        public CreateLoginValidator()
        {
            RuleFor(l => l.Email).NotEmpty();
            RuleFor(l => l.Password).NotEmpty();

        }
    }
}
