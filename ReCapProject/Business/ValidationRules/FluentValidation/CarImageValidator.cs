using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImagesDto>
    {
        public CarImageValidator()
        {

            When(x => x.Id == 0, () =>
            {
                RuleFor(x => x.CarId).NotNull().WithMessage("CarId boş geçilemez.");
            });

            When(x => x.CarId == 0, () =>
            {
                RuleFor(x => x.Id).NotNull().WithMessage("Id alanı boş geçilemez.");
            });

            RuleFor(x => x.ImageFile).NotNull();

            RuleFor(x => x.ImageFile.Length).LessThanOrEqualTo(1024 * 500)
                .WithMessage("Dosya boyutu en fazla 500kb olmalıdır.");

            RuleFor(x => x.ImageFile.ContentType).NotNull().Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage("Dosya türü desteklenmiyor!");
        }

    }
}
