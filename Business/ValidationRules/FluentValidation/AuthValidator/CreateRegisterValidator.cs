using Business.Dtos.Request.Auth;
using FluentValidation;
using System.Linq;
using System.Text.RegularExpressions;


namespace Business.ValidationRules.FluentValidation.AuthValidator
{
    public class CreateRegisterValidator:AbstractValidator<CreateRegisterRequest>
    {
        public CreateRegisterValidator()
        {
            RuleFor(r => r.Email).NotEmpty();
            RuleFor(r => r.Email).EmailAddress();

            RuleFor(r => r.Password).NotEmpty();
            RuleFor(r => r.Password).MinimumLength(3);


            RuleFor(r => r.FirstName).NotEmpty();
            RuleFor(r => r.FirstName).MinimumLength(2);
            RuleFor(r => r.LastName).MinimumLength(2);
            RuleFor(r => r.LastName).NotEmpty();




        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10;
        }
        private bool BeAValidNumber(string value)
        {
            return value.All(char.IsDigit);
        }
    }
}
