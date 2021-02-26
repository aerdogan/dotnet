using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(ci => ci.ImagePath).Must(x => x.EndsWith(".jpeg") || x.EndsWith(".jpg") || x.EndsWith(".png"))
                .WithMessage("Resim dosya türü desteklenmiyor!");
        }

    }
}
