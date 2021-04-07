using Core.Entities;
using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{

    public class LoginValidator : AbstractValidator<UserForLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email boş geçilemez.");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Email adres formatı hatalı.");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Şifre boş geçilemez.");
        }
    }

    public class RegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("İsim boş geçilemez.");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyisim boş geçilemez.");
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email boş geçilemez.");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Email adres formatı hatalı.");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Şifre boş geçilemez.");
            RuleFor(u => u.Password.Length).GreaterThanOrEqualTo(8).WithMessage("Şifre uzunluğu en az 8 karakter olmalı");
        }
    }
    
}
