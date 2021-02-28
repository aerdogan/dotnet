using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public partial class CarValidator
    {
        public class ColorValidator : AbstractValidator<Color>
        {
            public ColorValidator()
            {
                RuleFor(c => c.Name).NotEmpty();
                RuleFor(c => c.Id).GreaterThan(0);
            }
        }

    }
}
