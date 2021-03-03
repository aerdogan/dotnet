using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.ModelYear).GreaterThan(0).WithMessage("Araç model yılı boş geçilemez.");
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Araç günlük ücreti 0 dan büyük olmalıdır.");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Araç isim alanı boş geçilemez.");
        }
    }
}
