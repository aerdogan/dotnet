using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("İsim boş geçilemez.");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyisim boş geçilemez.");
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email boş geçilemez.");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Email adresi hatalı.");
        }
    }
}
