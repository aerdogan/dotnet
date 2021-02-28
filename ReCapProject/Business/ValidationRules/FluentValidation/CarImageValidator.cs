using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator<T> : AbstractValidator<CarImagesDto>
    {
        public CarImageValidator()
        {
            RuleFor(x => x.ImageFile).NotNull();

            RuleFor(x => x.ImageFile.Length).LessThanOrEqualTo(1024 * 500)
                    .WithMessage("Dosya boyutu en fazla 500kb olmalıdır.");

            RuleFor(x => x.ImageFile.ContentType).NotNull().Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                    .WithMessage("Dosya türü desteklenmiyor!");
        }
    }

    public class AddCarImageValidator : CarImageValidator<CarImagesDto>
    {
        public AddCarImageValidator()
        {
            RuleFor(x => x.CarId).GreaterThan(0).WithMessage("CarId boş geçilemez.");
        }
    }

    public class UpdateCarImageValidator : CarImageValidator<CarImagesDto>
    {
        public UpdateCarImageValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id alanı boş geçilemez.");
        }
    }
}
