using FluentValidation;
using SoundWave.DTO.AlbumDtos;

namespace SoundWave.Business.ValidationRules.AlbumValidation
{
    public class CreateAlbumValidator : AbstractValidator<CreateAlbumDto>
    {
        public CreateAlbumValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Albüm başlığı boş geçilemez.")
                .MinimumLength(3).WithMessage("Albüm başlığı en az 3 karakterden oluşmalıdır.")
                .MaximumLength(100).WithMessage("Albüm başlığı en fazla 100 karakterden oluşmalıdır.");

            RuleFor(x => x.CoverImageUrl)
                .NotEmpty().WithMessage("Albüm kapak görseli boş geçilemez.");

            RuleFor(x => x.ReleaseYear)
                .NotEmpty().WithMessage("Çıkış yılı boş geçilemez.")
                .InclusiveBetween(1900, DateTime.Now.Year).WithMessage($"Çıkış yılı 1900 ile {DateTime.Now.Year} arasında olmalıdır.");

            RuleFor(x => x.ArtistId)
                .GreaterThan(0).WithMessage("Lütfen geçerli bir sanatçı seçiniz.");
        }
    }
}
