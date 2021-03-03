using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            //RuleFor(c => c.Id).GreaterThan(0).WithMessage("Id alanı boş geçilemez.");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Renk alanı boş geçilemez.");
        }
    }

}
