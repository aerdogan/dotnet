using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public partial class CarValidator
    {
        public class BrandValidator : AbstractValidator<Brand>
        {
            public BrandValidator()
            {
                RuleFor(b => b.Name).NotEmpty();
                RuleFor(b => b.Id).GreaterThan(0);
            }
        }

    }
}
