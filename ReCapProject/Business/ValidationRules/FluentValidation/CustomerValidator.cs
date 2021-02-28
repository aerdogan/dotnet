using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public partial class CarValidator
    {
        public class CustomerValidator : AbstractValidator<Customer>
        {
            public CustomerValidator()
            {
                RuleFor(c => c.CompanyName).NotEmpty();
                RuleFor(c => c.Id).GreaterThan(0);
            }
        }

    }
}
