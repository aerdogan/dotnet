using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public partial class CarValidator
    {
        public class RentalValidator : AbstractValidator<Rental>
        {
            public RentalValidator()
            {
                RuleFor(r => r.CarId).GreaterThan(0);
                RuleFor(r => r.CustomerId).GreaterThan(0);
                RuleFor(r => r.RentDate).NotNull();
            }
        }

    }
}
